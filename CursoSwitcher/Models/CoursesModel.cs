using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoSwitcher.Models
{
    public class CoursesModel : CommonModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [ForeignKey("CareerModel")]
        public int CareerId { get; set; }

        [Display(Name = "Carrera")]
        public CareerModel? Career { get; set; }

    }
}
