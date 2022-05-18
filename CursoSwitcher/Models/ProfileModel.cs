namespace CursoSwitcher.Models
{
    public class ProfileModel : CommonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Dni { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Is_moderator { get; set; }

        public int IdCareer { get; set; }
        public CareerModel Career { get; set; }
        public int IdCourse{ get; set; }
        public CoursesModel courses { get; set; }
    }
}
