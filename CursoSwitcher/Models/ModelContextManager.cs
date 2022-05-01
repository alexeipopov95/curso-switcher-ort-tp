using Microsoft.EntityFrameworkCore;

namespace CursoSwitcher.Models
{
    public class ModelContextManager: DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CoursesModel> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(String.Format(@"Data Source={0}\..\database.db", Directory.GetCurrentDirectory()));
    }
}
