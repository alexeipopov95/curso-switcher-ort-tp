namespace CursoSwitcher.Models
{
    public class CoursesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseId { get; set; }
        public DateTime CreatedDate { get; set; }

        public CoursesModel()
        {
            this.CourseId = Guid.NewGuid().ToString();
            this.CreatedDate = DateTime.Now;
        }

    }
}
