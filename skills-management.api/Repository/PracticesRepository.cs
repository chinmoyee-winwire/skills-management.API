using Dapper;
using skills_management.api.Context;
using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace skills_management.api.Repository
{
    public class PracticesRepository : IPracticesRepository
    {
        private readonly SkillsManagementContext _skillsManagementContext;

        public PracticesRepository(SkillsManagementContext skillsManagementContext)
        {
            _skillsManagementContext = skillsManagementContext;
        }

        public async Task<IEnumerable<Practices>> GetAllPractices()
        {
            using (var dbConnection = _skillsManagementContext.CreateConnection())
            {
                var sql = "SELECT * FROM [dbo].[Practices] ORDER BY Id ASC";
                return await dbConnection.QueryAsync<Practices>(sql);
            }
        }

    }
}
