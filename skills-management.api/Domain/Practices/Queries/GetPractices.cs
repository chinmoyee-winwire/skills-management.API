using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.Practices.Queries
{
    public class GetPractices : IPractices
    {
        private readonly IMapper _mapper;
        private readonly IPracticesRepository _practicesRepository;

        public GetPractices(IMapper mapper, IPracticesRepository practicesRepository)
        {
            _mapper = mapper;
            _practicesRepository = practicesRepository;
        }
        public virtual async Task<IEnumerable<PracticesDto>> Execute()
        {
            var result = await _practicesRepository.GetAllPractices();
            return _mapper.Map<IEnumerable<PracticesDto>>(result);
        }
    }
}
