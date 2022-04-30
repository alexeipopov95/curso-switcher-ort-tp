using CursoSwitcher.Commons;

namespace CursoSwitcher.Models
{
    public class Request
    {
        public int id { get; set; }
        public int applicant_student { get; set; }
        public int requested_student { get; set; }
        public int requested_course { get; set; }
        public string Status { get; set; } = Constants.IN_PROGRESS_STATUS;

    }
}
