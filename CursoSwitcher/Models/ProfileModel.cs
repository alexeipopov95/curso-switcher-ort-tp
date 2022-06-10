using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoSwitcher.Models
{
    public class ProfileModel : CommonModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        public string Last_name { get; set; }

        [Display(Name = "Documento")]
        public string Dni { get; set; }
        public string Password { get; set; }

        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Administrador")]
        public bool Is_moderator { get; set; }

        public int? CourseId { get; set; }

        [Display(Name = "Curso")]
        public virtual CoursesModel Course { get; set; }

        [Display(Name = "Carrera")]
        [ForeignKey("CareerModel")]
        public int? CareerId { get; set; }
        public virtual CareerModel Career { get; set; }

        [Display(Name = "Sede")]
        [ForeignKey("CampusModel")]
        public int? CampusId { get; set; }
        public virtual CampusModel Campus { get; set; }

    }

}
