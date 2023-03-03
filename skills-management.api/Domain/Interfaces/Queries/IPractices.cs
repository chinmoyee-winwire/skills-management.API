using skills_management.api.Contracts.DTO;

namespace skills_management.api.Domain.Interfaces.Queries
{
    public interface IPractices
    {
        Task<IEnumerable<PracticesDto>> Execute();
    }
}
