using Dapper;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;

namespace TeamManagementApp.Repositories
{
    public interface IMainRepository
    {
        Task<List<TeamMember>> GetAllTeamMembers();
        Task<List<ProjectStatus>> GetAllProjectStatuses();
        Task<List<ProjectType>> GetAllProjectTypes();
        Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter, List<string> conditions);
    }

    public class MainRepository : IMainRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public MainRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }

        public async Task<List<TeamMember>> GetAllTeamMembers()
        {
            var query = @"select LiderId as MemberId, NumeLider as Name, Activ as Active, Ramura as Class, UserId from Lideri";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<TeamMember>(query);
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
        public async Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter, List<string> conditions)
        {
            var query = @"select p.ProiectId as ProjectId, p.NumeProiect as ProjectName, p.LiderCoordonator as Assignee, 
                        p.StatusId, p.TipId as TypeId, p.DataStart as StartDate, p.DataFinal as EndDate, 
                        l.NumeLider as AssigneeName, s.Status, t.Tip as Type
                        from Proiecte p
                        left join Lideri l on p.LiderCoordonator = l.LiderId
                        inner join StatusuriProiect s on p.StatusId = s.StatusId
                        inner join TipuriProiect t on p.TipId = t.TipId";
            if (conditions.Count > 0)
            {
                query = $"{query} where {string.Join(" and ", conditions)}"; 
            }
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<DetailedProject>(query, new
                {
                    project = $"%{filter.Project}%",
                    assignees = filter.Assignees,
                    statuses = filter.Statuses,
                    types = filter.Types
                });
                return result.ToList();
            }
        }
    }
}
