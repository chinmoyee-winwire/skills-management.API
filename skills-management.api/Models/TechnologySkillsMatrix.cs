namespace skills_management.api.Models
{
    public class TechnologySkillsMatrix
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public int TechnologyId { get; set; }
        public int? ProficiencyLevelId { get; set; }
    }
}
