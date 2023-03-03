using skills_management.api.Models;
using skills_management.api.Repository.Interfaces;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using skills_management.api.Context;

namespace skills_management.api.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly SkillsManagementContext _skillsManagementContext;

        public CategoriesRepository(SkillsManagementContext skillsManagementContext)
        {
            _skillsManagementContext = skillsManagementContext;
        }

        public async Task<IEnumerable<Categories>> GetAllCategories(int practiceId)
        {
            using (var dbConnection = _skillsManagementContext.CreateConnection())
            {
                var sql = "SELECT * FROM [dbo].[Categories] WHERE PracticesId=" + practiceId;
                dbConnection.Open();
                return await dbConnection.QueryAsync<Categories>(sql);
            }
        }

    }
}