﻿using Dapper;
using WinFormsApp1.Models;

namespace WinFormsApp1.Repositories
{
    public interface ILoginRepository
    {
        Task<UserLogin?> GetUserLogin(string user, string password);
        Task UpdateUserPassword(int userId, string password);
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
            var query = @"select * from Logins where UserName = @userName and (Password = @password or Password is null)";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserLogin>(query, new { userName = user, password = password });
                return result;
            }
        }

        public async Task UpdateUserPassword(int userId, string password)
        {
            var query = @"update Logins set Password = @password where userId = @userId and password is null";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                await connection.ExecuteAsync(query, new { userId = userId, password = password });
            }
        }
    }
}
