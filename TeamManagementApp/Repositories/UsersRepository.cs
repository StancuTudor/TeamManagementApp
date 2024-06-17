using Dapper;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IUsersRepository
    {
        Task<List<MemberAndUser>> GetAllUsersUsername();
        Task<List<MemberAndUser>> GetAllUsersMember();
        Task ResetPasswordOfUser(long userId);
        Task DeleteUser(long userId);
        Task RemoveMemberUserId(long userId);
        Task<long> InsertNewUser(UserLogin userLogin);
        Task UpdateUser(UserLogin userLogin);
        Task UpdateMemberUser(UserLogin userLogin);
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
                        left join Members m on m.UserId = l.UserId order by l.Username";
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
                        where m.UserId is not null order by m.Name";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<MemberAndUser>(query);
                return result.ToList();
            }
        }
        public async Task ResetPasswordOfUser(long userId)
        {
            var query = @"update Logins set Password = null where UserId = @userId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { userId });
            }
        }
        public async Task DeleteUser(long userId)
        {
            var query = @"delete from Logins where UserId = @userId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { userId });
            }
        }
        public async Task RemoveMemberUserId(long userId)
        {
            var query = @"update Members set UserId = null where UserId = @userId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { userId });
            }
        }
        public async Task<long> InsertNewUser(UserLogin userLogin)
        {
            var query = @"insert into Logins (Username) values (@username) returning UserId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstAsync<long>(query, new { username = userLogin.Username });
                return result;
            }
        }
        public async Task UpdateUser(UserLogin userLogin)
        {
            var query = @"update Logins set Username = @username where UserId = @userId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { username = userLogin.Username, userId = userLogin.UserId });
            }
        }
        public async Task UpdateMemberUser(UserLogin userLogin)
        {
            var query = @"update Members set UserId = @userId where MemberId = @memberId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { userId = userLogin.UserId, memberId = userLogin.MemberId });
            }
        }
    }
}
