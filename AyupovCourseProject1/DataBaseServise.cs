using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;

namespace AyupovCourseProject1
{
    public class DatabaseService
    {
        private readonly ApplicationContext context;

        /// <summary>
        /// Конструктор класса DatabaseService
        /// </summary>
        /// <param name="dbPath">Путь к базе данных</param>
        public DatabaseService(string dbPath)
        {
            context = new ApplicationContext(dbPath);
        }

        /// <summary>
        /// Создание новой базы данных
        /// </summary>
        /// <param name="filePath">Путь создания новой базы данных</param>
        public void CreateNewDatabase(string filePath)
        {
            var context = new ApplicationContext(filePath);

            context.Database.EnsureCreated();

        }

        /// <summary>
        /// Метод для сохранения базы данных
        /// </summary>
        /// <param name="sourceFilePath">Старый путь хранения базы данных</param>
        /// <param name="destinationFilePath">Новый путь хранения базы данных</param>
        /// <exception cref="FileNotFoundException">Исключение, вызывающееся, когда базу не получается найти по старому пути хранения</exception>
        public void SaveDatabase(string sourceFilePath, string destinationFilePath)
        {
            if (File.Exists(sourceFilePath))
            {
                File.Copy(sourceFilePath, destinationFilePath, overwrite: true);
            }
            else
            {
                throw new FileNotFoundException($"Файл по пути {sourceFilePath} не был найден");
            }
        }

        /// <summary>
        /// Загрузка базы данных
        /// </summary>
        /// <param name="filePath">Путь хранения базы данных</param>
        /// <exception cref="FileNotFoundException">Исключение, вызхывающееся, если путь хранения базы данных не найден</exception>
        public void LoadDatabase(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл по пути {filePath} не был найден");
            }

            ApplicationContext context = new ApplicationContext(filePath);
            List<MyDocument> documents = context.Documents.ToList();
            Console.WriteLine($"Loaded {documents.Count} documents from the database.");

        }

        /// <summary>
        /// Поиск документа по ID
        /// </summary>
        /// <param name="documentId">ID документа</param>
        /// <returns></returns>
        public MyDocument FindDocumentById(int documentId)
        {
            //IQueryable i = context.Documents.Select(x => x.ID == documentId);
            return context.Documents.Find(documentId);
        }

        public BindingList<MyDocument> SearchDocumentsByTitle(string title)
{
            var filteredDocuments = context.Documents.ToList()
                .Where(d => d.DocumentTitle.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
                

            return new BindingList<MyDocument>(filteredDocuments);
        }

        /// <summary>
        /// Редактирование документа
        /// </summary>
        /// <param name="documentId">ID документа</param>
        /// <param name="senderName">Имя отправителя</param>
        /// <param name="documentTitle">Заголовок документа</param>
        /// <param name="documentTopic">Тема документа</param>
        /// <param name="documentContent">Содержание документа</param>
        public void RedactDocument(int documentId, string senderName, string documentTitle, string documentTopic, string documentContent)
        {
            MyDocument document = FindDocumentById(documentId);
            document.SenderName = senderName;
            document.DocumentTitle = documentTitle;
            document.DocumentTopic = documentTopic;
            document.DocumentContent = documentContent;

            context.SaveChanges();
        }

        /// <summary>
        /// Создание документа
        /// </summary>
        /// <param name="senderName">Имя отправителя</param>
        /// <param name="documentTitle">Заголовок документа</param>
        /// <param name="receiptDate">Дата создания</param>
        /// <param name="documentTopic">Тема документа</param>
        /// <param name="documentContent">Содержание документа</param>
        public void CreateDocument(string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContent)
        {
            int Id;
            var rnd = new Random();
            MyDocument document = new MyDocument(senderName, documentTitle, receiptDate, documentTopic, documentContent);
            context.Documents.Add(document);
            context.SaveChanges();
        }

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="documentId">ID документа</param>
        public void DeleteDocument(int documentId)
        {
            MyDocument document = context.Documents.Find(documentId);
            context.Documents.Remove(document);
            context.SaveChanges();
        }

        public List<MyDocument> GetDocumentsByDate(DateTime startDate, DateTime endDate)
        {
            return context.Documents
                .Where(d => d.ReceiptDate >= startDate && d.ReceiptDate <= endDate)
                .ToList();
        }

        /// <summary>
        /// Получение таблицы базы данных в виде списка
        /// </summary>
        /// <returns>Таблица базы данных в виде списка</returns>
        public BindingList<MyDocument> GetDocuments()
        {
            var documents = context.Documents.ToList();
            return new BindingList<MyDocument>(documents);
            
        }

        /// <summary>
        /// Освобождение ресурсов 
        /// </summary>
        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
