using skills_management.api.Contracts.DTO;

namespace skills_management.api.Domain.Interfaces.Commands
{
    public interface IUpdateSkillMatrix
    {
        Task<int> Execute(List<TechnologyStackDto> technologyStack);
    }
}
