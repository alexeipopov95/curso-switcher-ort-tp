namespace CursoSwitcher.Models
{
    public class ProfileModelCourseModel
    {
        public int ProfileId { get; set; }
        public ProfileModel? Profile { get; set; }

        public int CourseId{ get; set; }
        public CoursesModel? Course  { get; set; }
    }
}
