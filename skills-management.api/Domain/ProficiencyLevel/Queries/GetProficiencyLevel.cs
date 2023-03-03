using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.ProficiencyLevel.Queries
{
    public class GetProficiencyLevel : IProficiencyLevel
    {
        private readonly IMapper _mapper;
        private readonly IProficiencyLevelRepository _plevelRepository;

        public GetProficiencyLevel(IMapper mapper, IProficiencyLevelRepository plevelRepository)
        {
            _mapper = mapper;
            _plevelRepository = plevelRepository;
        }
        public virtual async Task<IEnumerable<ProficiencyLevelDto>> Execute()
        {
            var result = await _plevelRepository.GetAllProficiencyLevels();
            return _mapper.Map<IEnumerable<ProficiencyLevelDto>>(result);
        }
    }
}
