using skills_management.api.Models;

namespace skills_management.api.Repository.Interfaces
{
    public interface ITechnologyStackRepository
    {
        Task<IEnumerable<TechnologyStack>?> GetTechnologyByCategoryId(int? categoryId);
    }
}
