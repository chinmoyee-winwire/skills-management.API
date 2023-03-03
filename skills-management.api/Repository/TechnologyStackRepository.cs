using Dapper;
using skills_management.api.Context;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System.Data;

namespace skills_management.api.Repository
{
    public class TechnologyStackRepository : ITechnologyStackRepository
    {
        private readonly SkillsManagementContext _skillsManagementContext;

        public TechnologyStackRepository(SkillsManagementContext skillsManagementContext)
        {
            _skillsManagementContext = skillsManagementContext;
        }
        public async Task<IEnumerable<TechnologyStack>?> GetTechnologyByCategoryId(int? categoryId)
        {
            using (var dbConnection = _skillsManagementContext.CreateConnection())
            {
                dbConnection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("CatageryId", categoryId);
                return await dbConnection.QueryAsync<TechnologyStack>("getTechnologyByCatageryID", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
