using Microsoft.EntityFrameworkCore;
using System.IO;



namespace CursoSwitcher.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Request> Requests { get; set; }  
    }
}
