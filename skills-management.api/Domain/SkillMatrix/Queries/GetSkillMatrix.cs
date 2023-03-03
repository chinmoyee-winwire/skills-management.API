﻿using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Domain.Interfaces.Queries;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;

namespace skills_management.api.Domain.SkillMatrix.Queries
{
    public class GetSkillMatrix : ISkillMatrix
    {
        private readonly IMapper _mapper;
        private readonly ISkillMatrixRepository _skillMatrixRepository;

        public GetSkillMatrix(IMapper mapper, ISkillMatrixRepository skillMatrixRepository)
        {
            _mapper = mapper;
            _skillMatrixRepository = skillMatrixRepository;
        }
        public virtual async Task<IEnumerable<SkillsMatrixDto>> Execute(string? skillName)
        {
            var result = await _skillMatrixRepository.GetAllSkills(skillName);
            var mappedResults = await MaptoDto(result);
            return mappedResults;
        }

        public virtual async Task<List<SkillsMatrixDto>> MaptoDto(IEnumerable<SkillsMatrixResults> skillMatrixResults)
        {
            List<SkillsMatrixDto> skilMatrixResultsDto = new List<SkillsMatrixDto>();
            int catID = 0;
            foreach (var skillMatrixResult in skillMatrixResults)
            {
                TechnologyStackDto technologyStackDto = new TechnologyStackDto();
                if (catID == skillMatrixResult.CategoryId)
                {
                    technologyStackDto.Id = skillMatrixResult.TechnologyId;
                    technologyStackDto.TechnologyName = skillMatrixResult.TechnologyName;
                    technologyStackDto.CategoryId = skillMatrixResult.CategoryId;
                    technologyStackDto.Selected = Convert.ToBoolean(skillMatrixResult.Selected);
                    technologyStackDto.SelectedProficiencyLevel = skillMatrixResult.SelectedProficiencyLevel;
                    int i = (int)(skilMatrixResultsDto.Count() - 1);
                    skilMatrixResultsDto[i].TechnologyStack.Add(technologyStackDto);

                }
                else
                {
                    SkillsMatrixDto skillMatrixDto = new SkillsMatrixDto();
                    skillMatrixDto.PracticeId = skillMatrixResult.PracticeId;
                    skillMatrixDto.PracticesName = skillMatrixResult.PracticesName;
                    skillMatrixDto.CategoryID = skillMatrixResult.CategoryId;
                    skillMatrixDto.CategoriesName = skillMatrixResult.CategoryName;
                    skillMatrixDto.EmployeeName = skillMatrixResult.EmployeeName;
                    technologyStackDto.Id = skillMatrixResult.TechnologyId;
                    technologyStackDto.TechnologyName = skillMatrixResult.TechnologyName;
                    technologyStackDto.CategoryId = skillMatrixResult.CategoryId;
                    technologyStackDto.Selected = Convert.ToBoolean(skillMatrixResult.Selected);
                    technologyStackDto.SelectedProficiencyLevel = skillMatrixResult.SelectedProficiencyLevel;
                    skillMatrixDto.TechnologyStack = new List<TechnologyStackDto>();
                    skillMatrixDto.TechnologyStack.Add(technologyStackDto);

                    skilMatrixResultsDto.Add(skillMatrixDto);
                }
                catID = skillMatrixResult.CategoryId;
            }
            return skilMatrixResultsDto;
        }
    }
}
