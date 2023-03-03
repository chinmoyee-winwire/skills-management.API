namespace skills_management.api.Models
{
    public class TechnologyStack
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public int CategoryId { get; set; }
        public int Selected { get; set; }
        public int? SelectedProficiencyLevel { get; set; }
    }
}
