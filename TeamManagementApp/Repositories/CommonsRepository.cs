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
            var query = @"select LiderId as MemberId, NumeLider as Name, Activ as Active, Ramura as Class, UserId from Lideri order by Name";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<Member>(query);
                return result.ToList();
            }
        }
        public async Task<List<ProjectStatus>> GetAllProjectStatuses()
        {
            var query = @"select StatusId, Status from StatusuriProiect";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<ProjectStatus>(query);
                return result.ToList();
            }
        }
        public async Task<List<ProjectType>> GetAllProjectTypes()
        {
            var query = @"select TipId as TypeId, Tip as Type from TipuriProiect";
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
            var query = @"select RamuraId as ClassId, NumeRamura as ClassName from Ramuri";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<MemberClass>(query);
                return result.ToList();
            }
        }
    }
}
