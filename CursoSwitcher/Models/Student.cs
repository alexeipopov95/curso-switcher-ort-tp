namespace CursoSwitcher.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_updated { get; set; }
        public bool status { get; set; }
        public string email { get; set; }
        public Request requests { get; set; }
        public Course Curso { get; set; }

        
    }
}
