using Dapper;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Repositories
{
    public interface IMainRepository
    {
        ServerConfigModel GetServerConfig();
        List<string> GetProjectFilterConditions(ProjectFilter filter);
        Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter, List<string> conditions);
        Task<DetailedProject?> GetProjectById(long projectId);
    }

    public class MainRepository : IMainRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public MainRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public ServerConfigModel GetServerConfig()
        {
            return _sqlProvider.GetServerConfig();
        }
        public List<string> GetProjectFilterConditions(ProjectFilter filter)
        {
            // Replace with the name of your column.
            string projectNameColumn = "ProjectName";
            string assigneeColumn = "Assignee";
            string statusColumn = "p.StatusId";
            string typeColumn = "p.TypeId";

            List<string> conditions = [];
            if (filter.ProjectSelection == Selection.Specific)
            {
                conditions.Add($"{projectNameColumn} like @project");
            }
            if (filter.AssigneeSelection == Selection.Specific)
            {
                conditions.Add($"{assigneeColumn} in ({string.Join(",", filter.Assignees)})");
            }
            if (filter.AssigneeSelection == Selection.Null)
            {
                conditions.Add($"{assigneeColumn} is null");
            }
            if (filter.StatusSelection == Selection.Specific)
            {
                conditions.Add($"{statusColumn} in ({string.Join(",", filter.Statuses)})");
            }
            if (filter.TypeSelection == Selection.Specific)
            {
                conditions.Add($"{typeColumn} in ({string.Join(",", filter.Types)})");
            }
            return conditions;
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
                    project = $"%{filter.Project}%"
                });
                return result.ToList();
            }
        }
        public async Task<DetailedProject?> GetProjectById(long projectId)
        {
            var query = @"select p.ProjectId, p.ProjectName, p.Assignee, 
                        p.StatusId, p.TypeId, p.StartDate, p.EndDate, p.Description, 
                        m.Name as AssigneeName, s.Status, t.Type
                        from Projects p
                        left join Members m on p.Assignee = m.MemberId
                        inner join ProjectStatuses s on p.StatusId = s.StatusId
                        inner join ProjectTypes t on p.TypeId = t.TypeId
                        where p.ProjectId = @projectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstOrDefaultAsync<DetailedProject>(query, new
                {
                    projectId = projectId
                });
                return result;
            }
        }
    }
}
