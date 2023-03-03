using AutoMapper;
using skills_management.api.Contracts.DTO;
using skills_management.api.Models;

namespace skills_management.api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Practices, PracticesDto>();
            CreateMap<Categories, CategoriesDto>();
            CreateMap<TechnologyStack, TechnologyStackDto>();

            CreateMap<ProficiencyLevel, ProficiencyLevelDto>();


            CreateMap<SkillsMatrixDto, SkillsMatrixResults>();
            CreateMap<SkillsMatrixDto, SkillsMatrixResults>().ReverseMap();
        }

    }
}
