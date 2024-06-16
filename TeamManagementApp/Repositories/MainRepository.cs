using Dapper;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;

namespace TeamManagementApp.Repositories
{
    public interface IMainRepository
    {
        Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter, List<string> conditions);
        ServerConfigModel GetServerConfig();
    }

    public class MainRepository : IMainRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public MainRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }
        public async Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter, List<string> conditions)
        {
            var query = @"select p.ProjectId, p.ProjectName, p.Assignee, 
                        p.StatusId, p.TypeId, p.StartDate, p.EndDate, p.Description, 
                        m.Name as AssigneeName, s.Status, t.Type
                        from Projects p
                        left join Members m on p.Assignee = m.MemberId
                        inner join ProjectStatuses s on p.StatusId = s.StatusId
                        inner join ProjectTypes t on p.TypeId = t.TypeId";
            if (conditions.Count > 0)
            {
                query = $"{query} where {string.Join(" and ", conditions)}";
            }
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<DetailedProject>(query, new
                {
                    project = $"%{filter.Project}%",
                    //assignees = filter.Assignees,
                    //statuses = filter.Statuses,
                    //types = filter.Types
                });
                return result.ToList();
            }
        }

        public ServerConfigModel GetServerConfig()
        {
            return _sqlProvider.GetServerConfig();
        }
    }
}
