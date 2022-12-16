
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext instance;
        public DbSet<Student> Student { get ; set; }
        private UniversityContext(DbContextOptions o) : base(o) { }
        public static UniversityContext getInstance()
        {
            if (instance == null)
            {
                instance=Instantiate_universityContext();
            }
            return instance;
        }
              private static UniversityContext Instantiate_universityContext()
        {
               var optionsbuilder = new DbContextOptionsBuilder<UniversityContext>();
               optionsbuilder.UseSqlite("Data Source=C:\\Users\\Louay\\Downloads\\2022 GL3 .NET Framework TP4 - SQLite database.db;");
                Debug.WriteLine("Instantiated for the last time");
                return new UniversityContext(optionsbuilder.Options);
         }
        
    }
}
