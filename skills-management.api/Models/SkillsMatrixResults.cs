namespace skills_management.api.Models
{
    public class SkillsMatrixResults
    {
        public string? EmployeeName { get; set; }
        public int PracticeId { get; set; }
        public string PracticesName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public int Selected { get; set; }
        public int SelectedProficiencyLevel { get; set; }
    }
}
