using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Commands;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.SkillMatrix.Commands
{
    public class UpdateSkillMatrix : IUpdateSkillMatrix
    {
        private readonly IMapper _mapper;
        private readonly ISkillMatrixRepository _skillMatrixRepository;

        public UpdateSkillMatrix(IMapper mapper, ISkillMatrixRepository skillMatrixRepository)
        {
            _mapper = mapper;
            _skillMatrixRepository = skillMatrixRepository;
        }
        public virtual async Task<int> Execute(List<TechnologyStackDto> technologyStackDto)
        {

            List<TechnologySkillsMatrix> technologySkillMatrixList = new List<TechnologySkillsMatrix>();

            foreach (var technologyStack in technologyStackDto)
            {

                TechnologySkillsMatrix techSkillMatrix = new TechnologySkillsMatrix();
                techSkillMatrix.TechnologyId = technologyStack.Id;
                techSkillMatrix.EmployeeName = "Chinmoyee P";
                techSkillMatrix.ProficiencyLevelId = technologyStack.SelectedProficiencyLevel;
                technologySkillMatrixList.Add(techSkillMatrix);

            }

            var result = await _skillMatrixRepository.CreateSkill(technologySkillMatrixList);
            return result;
        }
    }
}
