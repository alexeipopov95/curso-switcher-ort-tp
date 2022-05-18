using CursoSwitcher.Commons;

namespace CursoSwitcher.Models
{
    public class RequestsModel : CommonModel
    {
        public int Id { get; set; }
        public int IdProfile { get; set; }
        public ProfileModel Profile { get; set; }
        public int IdRequestedCoursed { get; set; }
        public CoursesModel RequestedCourse { get; set; }
        public int IdOfferedCourse { get; set; }
        public CoursesModel OfferedCourse { get; set; }
        public string status { get; set; }

        public RequestsModel()
        {
            this.status = RequestStatusConstants.PENDING;
        }
    }
}
