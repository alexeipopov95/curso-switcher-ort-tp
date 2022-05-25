using CursoSwitcher.Commons;
using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public class RequestsModel : CommonModel
    {
        [Key]
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public ProfileModel? Profile { get; set; }
        public int RequestedCourseId { get; set; }
        public CoursesModel? RequestedCourse { get; set; }
        public int OfferedCourseId { get; set; }
        public CoursesModel? OfferedCourse { get; set; }
        public string status { get; set; }

        public RequestsModel()
        {
            this.status = RequestStatusConstants.PENDING;
        }
    }
}
