using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public MyDocument FindDocumentById(int documentId)
        {
            return context.Documents.Find(documentId);
        }

        public void RedactDocument(int documentId, string senderName, string documentTitle, string documentTopic, string documentContent)
        {
            MyDocument document = FindDocumentById(documentId);
            document.SenderName = senderName;
            document.DocumentTitle = documentTitle;
            document.DocumentTopic = documentTopic;
            document.DocumentContent = documentContent;

            context.SaveChanges();
        }

        public void CreateDocument(string senderName, string documentTitle, DateTime receiptDate, string documentTopic, string documentContent)
        {
            MyDocument document = new MyDocument(senderName, documentTitle, receiptDate, documentTopic, documentContent);
            context.Documents.Add(document);
            context.SaveChanges();
        }

        public void DeleteDocument(int documentId)
        {
            MyDocument document = context.Documents.Find(documentId);
            context.Documents.Remove(document);
            MyDocument.CountOfElements = MyDocument.CountOfElements - 1;
            context.SaveChanges();
        }

        /// <summary>
        /// Получение таблицы базы данных в виде списка
        /// </summary>
        /// <returns>Таблица базы данных в виде списка</returns>
        public List<MyDocument> GetDocuments()
        {
            
            
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
