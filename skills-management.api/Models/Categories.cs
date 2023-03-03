namespace skills_management.api.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; } = null!;
        public int PracticesId { get; set; }
    }
}
