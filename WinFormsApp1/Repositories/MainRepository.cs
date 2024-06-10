using Dapper;

namespace TeamManagementApp.Repositories
{
    public interface IMainRepository
    {
        Task<string> Test();
    }

    public class MainRepository : IMainRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public MainRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<string> Test()
        {
            var query = @"select title from books";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstOrDefaultAsync<string>(query);
                return result;
            }
        }
    }
}
