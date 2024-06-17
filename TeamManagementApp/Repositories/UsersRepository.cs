using Dapper;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IUsersRepository
    {
        Task<List<MemberAndUser>> GetAllUsersUsername();
        Task<List<MemberAndUser>> GetAllUsersMember();
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public UsersRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<List<MemberAndUser>> GetAllUsersUsername()
        {
            var query = @"select l.UserId, l.Username, m.MemberId from Logins l
                        left join Members m on m.UserId = l.UserId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<MemberAndUser>(query);
                return result.ToList();
            }
        }
        public async Task<List<MemberAndUser>> GetAllUsersMember()
        {
            var query = @"select l.UserId, m.Name as MemberName, m.MemberId, l.UserName
                        from Members m
                        inner join Logins l on m.UserId = l.UserId
                        where m.UserId is not null";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<MemberAndUser>(query);
                return result.ToList();
            }
        }
    }
}
