using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Commands;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.SkillMatrix.Commands
{
    public class CreateSkillMatrix : ICreateSkillMatrix
    {
        private readonly IMapper _mapper;
        private readonly ISkillMatrixRepository _skillMatrixRepository;

        public CreateSkillMatrix(IMapper mapper, ISkillMatrixRepository skillMatrixRepository)
        {
            _mapper = mapper;
            _skillMatrixRepository = skillMatrixRepository;
        }
        public virtual async Task<int> Execute(List<SkillsMatrixDto> skillMatrixtoList)
        {

            List<TechnologySkillsMatrix> technologySkillMatrixList = new List<TechnologySkillsMatrix>();

            foreach (var skillMatrixDto in skillMatrixtoList)
            {
                var techIndex = 0;
                foreach (var techStack in skillMatrixDto.TechnologyStack)
                {
                    TechnologySkillsMatrix techSkillMatrix = new TechnologySkillsMatrix();
                    techSkillMatrix.TechnologyId = skillMatrixDto.TechnologyStack[techIndex].Id;
                    techSkillMatrix.EmployeeName = skillMatrixDto.EmployeeName;
                    techSkillMatrix.ProficiencyLevelId = skillMatrixDto.TechnologyStack[techIndex].SelectedProficiencyLevel;
                    technologySkillMatrixList.Add(techSkillMatrix);
                    techIndex++;
                }
            }

            var result = await _skillMatrixRepository.CreateSkill(technologySkillMatrixList);
            return result;
        }
    }
}
