using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public abstract class CommonModel
    {
        [Display(Name = "ID Público")]
        public string Visible_id { get; set; } = Guid.NewGuid().ToString();

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de creación")]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        [Display(Name = "Última actualización")]
        public DateTime Updated_at { get; set; } = DateTime.Now;

    }
}
