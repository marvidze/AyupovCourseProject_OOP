using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.VisualBasic.ApplicationServices;

namespace AyupovCourseProject1
{
    public class ApplicationContext : DbContext
    {
        private readonly string dbPath;

        /// <summary>
        /// Коллекция, представляющая таблицу базы данных
        /// </summary>
        public DbSet<MyDocument> Documents { get; set; } = null!;

        /// <summary>
        /// Конструктор класса ApplicationContext
        /// </summary>
        /// <param name="dbPath"></param>
        public ApplicationContext(string dbPath)
        {
            this.dbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={this.dbPath}");
        }
    }
}
