using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public class CampusModel : CommonModel // SEDE
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        public List<ProfileModel>? Profile { get; set; }

    }
}
