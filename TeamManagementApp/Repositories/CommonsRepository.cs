using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Models;
using TeamManagementApp.Utils;
using Dapper;

namespace TeamManagementApp.Repositories
{
    public interface ICommonRepository
    {
        Task<List<Member>> GetAllMembers(ActiveSelection active);
        Task<List<ProjectStatus>> GetAllProjectStatuses();
        Task<List<ProjectType>> GetAllProjectTypes(ActiveSelection active);
        Task<List<UserLogin>> GetAllUsers();
        Task<List<MemberClass>> GetAllMemberClasses(ActiveSelection active);
    }

    public class CommonRepository : ICommonRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public CommonRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<List<Member>> GetAllMembers(ActiveSelection active)
        {
            string condition = string.Empty;
            if(active != ActiveSelection.All)
            {
                condition = "where active = @active";
            }

            var query = $@"select MemberId, Name, Active, ClassId, UserId from Members {condition} order by Name";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<Member>(query, new { active = (int)active } );
                return result.ToList();
            }
        }
        public async Task<List<ProjectStatus>> GetAllProjectStatuses()
        {
            var query = $@"select StatusId, Status, Active from ProjectStatuses";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<ProjectStatus>(query);
                return result.ToList();
            }
        }
        public async Task<List<ProjectType>> GetAllProjectTypes(ActiveSelection active)
        {
            string condition = string.Empty;
            if (active != ActiveSelection.All)
            {
                condition = "where active = @active";
            }

            var query = $@"select TypeId, Type, Active from ProjectTypes {condition}";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<ProjectType>(query, new { active = (int)active });
                return result.ToList();
            }
        }
        public async Task<List<UserLogin>> GetAllUsers()
        {
            var query = $@"select UserId, UserName from Logins order by UserName";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<UserLogin>(query);
                return result.ToList();
            }
        }
        public async Task<List<MemberClass>> GetAllMemberClasses(ActiveSelection active)
        {
            string condition = string.Empty;
            if (active != ActiveSelection.All)
            {
                condition = "where active = @active";
            }

            var query = $@"select ClassId, ClassName, Active from MemberClasses {condition}";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<MemberClass>(query, new { active = (int)active });
                return result.ToList();
            }
        }
    }
}
