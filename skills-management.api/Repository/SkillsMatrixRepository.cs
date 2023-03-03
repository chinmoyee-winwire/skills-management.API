using Dapper;
using skills_management.api.Context;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System.Data;

namespace skills_management.api.Repository
{
    public class SkillsMatrixRepository : ISkillMatrixRepository
    {
        private readonly SkillsManagementContext _skillsManagementContext;

        public SkillsMatrixRepository(SkillsManagementContext skillsManagementContext)
        {
            _skillsManagementContext = skillsManagementContext;
        }
        public async Task<int> CreateSkill(List<TechnologySkillsMatrix> technologySkillsMatrix)
        {
            foreach (var techSKillMatrix in technologySkillsMatrix)
            {
                using (var dbConnection = _skillsManagementContext.CreateConnection())
                {
                        // Deleting the record first
                        var deleteSql = $"DELETE FROM [dbo].[TechnologySkillsMatrix] WHERE TechnologyId = @technologyId ";
                        await dbConnection.ExecuteAsync(deleteSql, new { techSKillMatrix.TechnologyId });
                 
                        // Inserting the new skill
                        var insertSql = @"INSERT INTO [dbo].[TechnologySkillsMatrix] (EmployeeName, TechnologyId, ProficiencyLevelId)
                                             VALUES (@employeeName, @technologyId, @proficiencyLevelId)";
                       
                        
                        dbConnection.Execute(insertSql, new { employeeName = techSKillMatrix.EmployeeName, technologyId = techSKillMatrix.TechnologyId, proficiencyLevelId = techSKillMatrix.ProficiencyLevelId });
                    }
            }
            var res = 1;
            return res;
        }

        public async Task<IEnumerable<SkillsMatrixResults>> GetAllSkills(string? searchText)
        {
            if (searchText == null)
            {
                return null;
            }
            using (var dbConnection = _skillsManagementContext.CreateConnection())
            {
                dbConnection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("SearchText", searchText);
                return await dbConnection.QueryAsync<SkillsMatrixResults>("getTechnologyProficientlevelBySearchText", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
