using skills_management.api.Models;

namespace skills_management.api.Repository.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Categories>> GetAllCategories(int practiceId);
    }
}
