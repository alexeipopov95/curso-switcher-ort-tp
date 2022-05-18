using Microsoft.EntityFrameworkCore;

namespace CursoSwitcher.Models
{
    public class ModelContextManager: DbContext
    {
        public DbSet<CampusModel> Campus { get; set; }
        public DbSet<CareerModel> Careers { get; set; }
        public DbSet<CoursesModel> Courses { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<RequestsModel> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(String.Format(@"Data Source={0}\..\database.db", Directory.GetCurrentDirectory()));
    }
}
