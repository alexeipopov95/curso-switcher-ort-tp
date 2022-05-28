using CursoSwitcher.Commons;
using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public class RequestsModel : CommonModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Alumno")]
        public int ProfileId { get; set; }
        public ProfileModel? Profile { get; set; }

        [Display(Name = "Curso solicitado")]
        public int RequestedCourseId { get; set; }
        public CoursesModel? RequestedCourse { get; set; }

        [Display(Name = "Curso ofrecido")]
        public int OfferedCourseId { get; set; }
        public CoursesModel? OfferedCourse { get; set; }

        [Display(Name = "Estado")]
        public string status { get; set; }

        public RequestsModel()
        {
            this.status = RequestStatusConstants.PENDING;
        }
    }
}
