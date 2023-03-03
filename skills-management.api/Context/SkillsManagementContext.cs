using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Data;
using skills_management.api.Contracts;

namespace skills_management.api.Context
{
    public class SkillsManagementContext
    {
        private ConnectionStringOptions connectionStringOptions;
        public SkillsManagementContext(IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        {
            connectionStringOptions = optionsMonitor.CurrentValue;
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionStringOptions.SqlConnection);
    }
}
