using skills_management.api.Models;

namespace skills_management.api.Repository.Interfaces
{
    public interface ISkillMatrixRepository
    {
        Task<IEnumerable<SkillsMatrixResults>> GetAllSkills(string? skillName);

        Task<int> CreateSkill(List<TechnologySkillsMatrix> technologySkillsMatrix);
    }
}
