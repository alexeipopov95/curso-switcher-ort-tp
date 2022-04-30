namespace CursoSwitcher.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime time_from { get; set; }
        public DateTime time_until { get; set; }
        public int day_available { get; set; }
        public bool is_full { get; set; }
        public string public_id { get; set; }

    }
}
