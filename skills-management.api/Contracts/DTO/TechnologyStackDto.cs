namespace skills_management.api.Contracts.DTO
{
    public class TechnologyStackDto
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public int? CategoryId { get; set; }
        public Boolean Selected { get; set; }
        public int? SelectedProficiencyLevel { get; set; }
    }
}
