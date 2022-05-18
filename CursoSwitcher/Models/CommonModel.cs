using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public abstract class CommonModel
    {
        [Display(Name = "ID Público")]
        public string Visible_id { get; set; } = Guid.NewGuid().ToString();
        [Display(Name = "Fecha de creación")]
        public DateTime Created_at { get; set; } = DateTime.Now;
        [Display(Name = "Última actualización")]
        public DateTime Updated_at { get; set; } = DateTime.Now;

    }
}
