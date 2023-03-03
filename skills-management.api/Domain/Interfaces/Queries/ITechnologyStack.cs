using skills_management.api.Contracts.DTO;

namespace skills_management.api.Domain.Interfaces.Queries
{
    public interface ITechnologyStack
    {
        Task<IEnumerable<TechnologyStackDto>> ExecuteByCategoryId(int? categoryId);
    }
}
