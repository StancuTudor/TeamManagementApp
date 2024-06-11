using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Models;
using Dapper;

namespace TeamManagementApp.Repositories
{
    public interface ICommonRepository
    {
        Task<List<Member>> GetAllMembers();
        Task<List<ProjectStatus>> GetAllProjectStatuses();
        Task<List<ProjectType>> GetAllProjectTypes();
        Task<List<UserLogin>> GetAllUsers();
        Task<List<MemberClass>> GetAllMemberClasses();
    }

    public class CommonRepository : ICommonRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public CommonRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            var query = @"select MemberId, Name, Active, ClassId, UserId from Members order by Name";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<Member>(query);
                return result.ToList();
            }
        }
        public async Task<List<ProjectStatus>> GetAllProjectStatuses()
        {
            var query = @"select StatusId, Status from ProjectStatuses";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<ProjectStatus>(query);
                return result.ToList();
            }
        }
        public async Task<List<ProjectType>> GetAllProjectTypes()
        {
            var query = @"select TypeId, Type from ProjectTypes";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<ProjectType>(query);
                return result.ToList();
            }
        }
        public async Task<List<UserLogin>> GetAllUsers()
        {
            var query = @"select UserId, UserName from Logins order by UserName";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<UserLogin>(query);
                return result.ToList();
            }
        }
        public async Task<List<MemberClass>> GetAllMemberClasses()
        {
            var query = @"select ClassId, ClassName from MemberClasses";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<MemberClass>(query);
                return result.ToList();
            }
        }
    }
}
