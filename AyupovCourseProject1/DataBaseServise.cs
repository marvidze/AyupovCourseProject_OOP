using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AyupovCourseProject1
{
    public class DatabaseService
    {
        private readonly ApplicationContext _context;
        public DatabaseService(string dbPath)
        {
            _context = new ApplicationContext(dbPath);
        }
        public void CreateNewDatabase(string filePath)
        {
            var context = new ApplicationContext(filePath);

            context.Database.EnsureCreated();

        }

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

        public void LoadDatabase(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл по пути {filePath} не был найден");
            }

            using (var context = new ApplicationContext(filePath))
            {
                var documents = context.Documents.ToList();
                Console.WriteLine($"Loaded {documents.Count} documents from the database.");
            }
        }

        public List<MyDocument> GetDocuments()
        {
            return _context.Documents.ToList();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
