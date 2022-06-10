using CursoSwitcher.Commons;
using System.ComponentModel.DataAnnotations;

namespace CursoSwitcher.Models
{
    public class RequestsModel : CommonModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Solicitante")]
        public int ProfileId { get; set; }
        public ProfileModel? Profile { get; set; }
        [Display(Name = "Curso solicitado")]
        public int RequestedCourseId { get; set; }
        public CoursesModel RequestedCourse { get; set; }
        [Display(Name = "Curso ofrecido")]
        public int OfferedCourseId { get; set; }
        public CoursesModel OfferedCourse { get; set; }
        [Display(Name = "Estado")]
        public string status { get; set; }

        public RequestsModel()
        {
            this.status = RequestStatusConstantsList.PENDIENTE;
        }

        public class RequestModelMatch
        {
            [Display(Name = "Curso solicitado")]
            public int RequestedCourseId { get; set; }
            public string? RequestedCourseName { get; set; }
            [Display(Name = "Curso ofrecido")]
            public int OfferedCourseId { get; set; }
            public string? OfferedCourseName { get; set; }
            [Display(Name = "Id del ofrecedor")]
            public int OffererId { get; set; }
            [Display(Name = "Id del solicitante")]
            public int RequesterId{ get; set; }

            public RequestModelMatch(
                int requestedCourseId,
                int offeredCourseId,
                int offererId,
                int requesterId,
                string requestedCourseName,
                string offeredCourseName
            )
            {
                RequestedCourseId = requestedCourseId;
                OfferedCourseId = offeredCourseId;
                OffererId = offererId;
                RequesterId = requesterId;
                RequestedCourseName = requestedCourseName;
                OfferedCourseName = offeredCourseName;


            }
        }

    }
}
