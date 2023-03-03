namespace skills_management.api.Contracts.DTO
{
    public class SkillsMatrixDto
    {
        public int? PracticeId { get; set; }
        public string? EmployeeName { get; set; }
        public string PracticesName { get; set; }

        public int? CategoryID { get; set; }

        public string CategoriesName { get; set; }
        public List<TechnologyStackDto> TechnologyStack { get; set; }
    }
}
