using skills_management.api.Contracts.DTO;

namespace skills_management.api.Domain.Interfaces.Commands
{
    public interface ICreateSkillMatrix
    {
        Task<int> Execute(List<SkillsMatrixDto> skillMatrix);
    }
}
