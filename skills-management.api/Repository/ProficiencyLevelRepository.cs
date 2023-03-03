using Dapper;
using skills_management.api.Context;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace skills_management.api.Repository
{
    public class ProficiencyLevelRepository : IProficiencyLevelRepository
    {
        private readonly SkillsManagementContext _skillsManagementContext;

        public ProficiencyLevelRepository(SkillsManagementContext skillsManagementContext)
        {
            _skillsManagementContext = skillsManagementContext;
        }
        public async Task<IEnumerable<ProficiencyLevel>> GetAllProficiencyLevels()
        {
            using (var dbConnection = _skillsManagementContext.CreateConnection())
            {
                var sql = "SELECT * FROM dbo.proficiencyLevel ORDER BY Id ASC";
                return await dbConnection.QueryAsync<ProficiencyLevel>(sql);
            }
        }
    }
}
