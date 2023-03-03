namespace skills_management.api.Models
{
    public class Practices
    {
        public int Id { get; set; }
        public string PracticeName { get; set; }
        public string Description { get; set; } = null!;
    }
}
