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
        private ApplicationContext context;
        private string dbPath;

        /// <summary>
        /// Конструктор класса DatabaseService
        /// </summary>
        /// <param name="dbPath">Путь к базе данных</param>
        public DatabaseService(string dbPath)
        {
            this.dbPath = dbPath;
            context = new ApplicationContext(this.dbPath);
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

            ApplicationContext context = new(filePath);
            List<MyDocument> documents = context.Documents.ToList();
        }

        /// <summary>
        /// Поиск документа по ID
        /// </summary>
        /// <param name="documentId">ID документа</param>
        /// <returns></returns>
        public MyDocument FindDocumentById(int documentId)
        {
            //IQueryable i = context.Documents.Select(x => x.ID == documentId);
            context.ChangeTracker.Clear();
            return context.Documents.Find(documentId);
        }
        
        /// <summary>
        /// Получить количество документов в базе данных
        /// </summary>
        /// <returns>кол-во документов в БД</returns>
        public int GetCountOfDocuments()
        {
            return context.Documents.Count();
        }

        /// <summary>
        /// Поиск документа по заголовку
        /// </summary>
        /// <param name="title">заголовок</param>
        /// <returns>Список документов, количество документов в списке</returns>
        public (List<MyDocument>, int) SearchDocumentsByTitle(string title)
        { 
            List<MyDocument> resultList = context.Documents.ToList()
                .Where(d => d.DocumentTitle.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            return (resultList, resultList.Count());
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
            context.Entry(document).Reload();
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
            Random rnd = new();
            MyDocument document = new(senderName, documentTitle, receiptDate, documentTopic, documentContent);
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

        /// <summary>
        /// Получить документы по дате
        /// </summary>
        /// <param name="startDate">начало отсчёта даты</param>
        /// <param name="endDate">конец отсчёта даты</param>
        /// <returns>список документов, количество элементов в списке</returns>
        public (List<MyDocument>, int) GetDocumentsByDate(DateTime startDate, DateTime endDate)
        {
            List<MyDocument> resultList = [.. context.Documents.Where(d => d.ReceiptDate >= startDate && d.ReceiptDate <= endDate)];
            int countOfElems = resultList.Count();
            return (resultList, countOfElems);
        }

        /// <summary>
        /// Получение таблицы базы данных в виде списка
        /// </summary>
        /// <returns>Таблица базы данных в виде списка</returns>
        public List<MyDocument> GetDocuments()
        {
            context = new ApplicationContext(this.dbPath);
            return context.Documents.ToList(); 
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
