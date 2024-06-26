﻿using Dapper;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface ILoginRepository
    {
        Task<UserLogin?> GetUserLogin(string user, string password);
        Task UpdateUserPassword(long userId, string password);
        Task<AppVersionModel> GetAppVersion();
    }

    public class LoginRepository : ILoginRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public LoginRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<UserLogin?> GetUserLogin(string user, string password)
        {
            var query = @"select logins.UserId, Username, Password, memberId from Logins
                          left join Members on logins.UserId = Members.UserId 
                          where Username = @username and (Password = @password or Password is null)";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserLogin>(query, new { username = user, password = password });
                return result;
            }
        }

        public async Task UpdateUserPassword(long userId, string password)
        {
            var query = @"update Logins set Password = @password where userId = @userId and password is null";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new { userId = userId, password = password });
            }
        }

        public async Task<AppVersionModel> GetAppVersion()
        {
            var query = @"select MinVersion, LatestVersion from AppVersion";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstAsync<AppVersionModel>(query);
                return result;
            }
        }
    }
}
