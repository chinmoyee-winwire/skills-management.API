using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.Category.Queries
{
    public class GetCategories: ICategories
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;

        public GetCategories(IMapper mapper, ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
        }
        public virtual async Task<IEnumerable<CategoriesDto>> Execute(int practiceId)
        {
            var result = await _categoriesRepository.GetAllCategories(practiceId);
            return _mapper.Map<IEnumerable<CategoriesDto>>(result);
        }
    }
}
