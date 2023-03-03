using skills_management.api.Models;

namespace skills_management.api.Repository.Interfaces
{
    public interface IProficiencyLevelRepository
    {
        Task<IEnumerable<ProficiencyLevel>> GetAllProficiencyLevels();
    }
}
