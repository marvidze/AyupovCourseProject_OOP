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
        private readonly string _dbPath;
        public DbSet<MyDocument> Documents { get; set; } = null!;

        public ApplicationContext(string dbPath)
        {
            _dbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
