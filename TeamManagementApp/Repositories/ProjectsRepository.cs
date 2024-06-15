using Dapper;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IProjectsRepository
    {
        Task<List<Member>> GetMembersByClassId(long classId);
    }
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public ProjectsRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<List<Member>> GetMembersByClassId(long classId)
        {
            var query = @"select Name, MemberId from Members where ClassId = @memberClassId and Active = 1";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<Member>(query, new { memberClassId = classId });
                return result.ToList();
            }
        }
    }
}
