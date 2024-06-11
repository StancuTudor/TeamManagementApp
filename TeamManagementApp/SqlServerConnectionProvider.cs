using TeamManagementApp.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace TeamManagementApp
{
    public interface ISqlServerConnectionProvider
    {
        IDbConnection GetDbConnectionMain();
    }

    public class SqlServerConnectionProvider : ISqlServerConnectionProvider
    {
        private readonly ConnectionStringOptions _options;

        public SqlServerConnectionProvider(IOptions<ConnectionStringOptions> options)
        {
            _options = options.Value;
        }

        public IDbConnection GetDbConnectionMain()
        {
            return new SqlConnection(_options.DbConnectionMain);
        }
    }
}
