using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public class CampusModel : CommonModel // SEDE
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
