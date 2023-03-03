using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.TechnologyStack.Queries
{
    public class GetTechnologyStack : ITechnologyStack
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyStackRepository _techstackRepository;

        public GetTechnologyStack(IMapper mapper, ITechnologyStackRepository techstackRepository)
        {
            _mapper = mapper;
            _techstackRepository = techstackRepository;
        }

        public virtual async Task<IEnumerable<TechnologyStackDto>> ExecuteByCategoryId(int? categoryId)
        {
            var result = await _techstackRepository.GetTechnologyByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<TechnologyStackDto>>(result);
        }
    }
}
