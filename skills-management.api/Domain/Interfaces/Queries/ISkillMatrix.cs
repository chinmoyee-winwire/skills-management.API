using skills_management.api.Contracts.DTO;

namespace skills_management.api.Domain.Interfaces.Queries
{
    public interface ISkillMatrix
    {
        Task<IEnumerable<SkillsMatrixDto>> Execute(string? skillName);
    }
}
