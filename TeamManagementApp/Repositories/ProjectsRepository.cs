using Dapper;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IProjectsRepository
    {
        Task<List<Member>> GetMembersByClassId(long classId);
        Task<Project?> GetProjectDataById(long projectId);
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

        public async Task<Project?> GetProjectDataById(long projectId)
        {
            var query = @"select ProjectId, ProjectName, Assignee, StatusId, TypeId, StartDate, EndDate, Description 
                            from Projects where ProjectId = @projectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstOrDefaultAsync<Project>(query, new { projectId = @projectId });
                return result;
            }
        }
    }
}
