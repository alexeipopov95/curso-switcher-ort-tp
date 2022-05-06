namespace CursoSwitcher.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string StudentId { get; set; }
        public DateTime CreatedDate { get; set; }

        // https://entityframework.net/knowledge-base/38183021/how-to-automatically-populate-createddate-and-modifieddate-
        public StudentModel()
        {
            this.StudentId = Guid.NewGuid().ToString();
            this.CreatedDate = DateTime.Now;
        }
    }
}
