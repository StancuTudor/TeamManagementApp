using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using TeamManagementApp.Models;
using TeamManagementApp.Options;
using TeamManagementApp.Utils;

namespace TeamManagementApp
{
    public interface ISqlServerConnectionProvider
    {
        IDbConnection GetDbConnectionMain();
        ServerConfigModel GetServerConfig();
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
            return new NpgsqlConnection(_options.DbConnectionMain);
        }
        public ServerConfigModel GetServerConfig()
        {
            var sqlConnection = new NpgsqlConnection(_options.DbConnectionMain);
            return new ServerConfigModel() { 
                Server = sqlConnection.DataSource, 
                Database = sqlConnection.Database 
            };
        }
    }
}
