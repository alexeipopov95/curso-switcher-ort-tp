using Microsoft.EntityFrameworkCore;

namespace CursoSwitcher.Models
{
    public class ModelContextManager: DbContext
    {
        // Creamos las propiedades de nuestro manager (es como accederemos a cada tabla en nuestro código)
        public DbSet<CampusModel> Campus { get; set; }
        public DbSet<CareerModel> Careers { get; set; }
        public DbSet<CoursesModel> Courses { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<RequestsModel> Requests { get; set; }


        // Le decimos a donde tiene que ir a buscar la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(String.Format(@"Data Source={0}\..\database.db", Directory.GetCurrentDirectory()));

        // ¿Como ingresamos información al momento de inicializar la base de datos? - Sobreescribimos el método OnModelCreating.
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CampusModel>().HasData(

                // Campus Initial Values
                new CampusModel {
                    Id = 1,
                    Name = "Yatay",
                    Description = "Sede Almagro\nDirección: Yatay 240\nProvincia: Buenos Aires\nPais: Argentina\nTeléfono: 4958-9000"
                },
                new CampusModel {
                    Id = 2,
                    Name = "Belgrano",
                    Description = "Sede Belgrano\nDirección: Av. del Libertador 6796\nProvincia: Buenos Aires\nPais: Argentina\nTeléfono: 4789-6500 "
                }
            );

            modelBuilder.Entity<CareerModel>().HasData(
            // Career Initial Values
            new CareerModel
                {
                    Id = 1,
                    Name = "Analista de Sistemas",
                    Description = "Duración: 2 años.\nTitulo Otorgado: Analista de Sistemas."
                },
                new CareerModel
                {
                    Id = 2,
                    Name = "Biotecnología",
                    Description = "Duración: 3 años.\nTitulo Otorgado: Técnico Superior en Química y Biotecnología."
                },
                new CareerModel
                {
                    Id = 3,
                    Name = "Sonido y Producción Musical",
                    Description = "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Producción Musical."
                },
                new CareerModel
                {
                    Id = 4,
                    Name = "Diseño Digital",
                    Description = "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Diseño Gráfico Digital."
                },
                new CareerModel
                {
                    Id = 5,
                    Name = "Diseño Industrial",
                    Description = "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Diseño Industrial."
                }
            );

            modelBuilder.Entity<CoursesModel>().HasData(
            // Courses Initial Values
            new CoursesModel
                {
                    Id = 1,
                    Name = "11A",
                    Description = "Analista de Sistemas 1er año 1°A",
                    CareerId = 1
                },
                new CoursesModel
                {
                    Id = 2,
                    Name = "11B",
                    Description = "Analista de Sistemas 1er año 1°B",
                    CareerId = 1
                },
                new CoursesModel
                {
                    Id = 3,
                    Name = "11C",
                    Description = "Analista de Sistemas 1er año 1°C",
                    CareerId = 1
                },
                new CoursesModel
                {
                    Id = 4,
                    Name = "11D",
                    Description = "Analista de Sistemas 1er año 1°D",
                    CareerId = 1
                },
                new CoursesModel
                {
                    Id = 5,
                    Name = "21A",
                    Description = "Biotecnología Segundo año 1°A",
                    CareerId = 2
                },
                new CoursesModel
                {
                    Id = 6,
                    Name = "21B",
                    Description = "Biotecnología Segundo año 1°B",
                    CareerId = 2
                },
                new CoursesModel
                {
                    Id = 7,
                    Name = "21C",
                    Description = "Biotecnología Segundo año 1°C",
                    CareerId = 2
                },
                new CoursesModel
                {
                    Id = 8,
                    Name = "21D",
                    Description = "Biotecnología Segundo año 1°D",
                    CareerId = 2
                },
                new CoursesModel
                {
                    Id = 9,
                    Name = "22A",
                    Description = "Sonido y Producción Musical Segundo año 2°A",
                    CareerId = 3
                },
                new CoursesModel
                {
                    Id = 10,
                    Name = "22B",
                    Description = "Sonido y Producción Musical Segundo año 2°B",
                    CareerId = 3
                },
                new CoursesModel
                {
                    Id = 11,
                    Name = "22C",
                    Description = "Sonido y Producción Musical Segundo año 2°C",
                    CareerId = 3
                },
                new CoursesModel
                {
                    Id = 12,
                    Name = "22D",
                    Description = "Sonido y Producción Musical Segundo año 2°D",
                    CareerId = 3
                }
            );

            modelBuilder.Entity<ProfileModel>().HasData(
            // Profile Initial Values
            // Only Admin
            new ProfileModel
                {
                    Id = 1,
                    Name = "ADMIN",
                    Last_name = "ADMIN",
                    Dni = "ADMIN",
                    Password = "ADMIN",
                    Email = "secretaria-ites1@ort.edu.ar",
                    Is_moderator = true,
            }
        );
        }
    }
}
