using Dapper;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repositories
{
    public interface IProjectsRepository
    {
        Task<List<Member>> GetMembersByClassId(long classId);
        Task<Project?> GetProjectDataById(long projectId);
        Task<List<Member>> GetMembersOfProject(long projectId);
        Task DeleteProjectMembers(long projectId);
        Task DeleteProjectById(long projectId);
        Task<long> InsertNewProject(Project newProject);
        Task UpdateProject(Project updatedProject);
        Task DeleteProjectMembersNotInProject(long projectId, List<long> members);
        Task InsertProjectMembers(long projectId, List<long> members);
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
                var result = await connection.QueryFirstOrDefaultAsync<Project>(query, new { projectId = projectId });
                return result;
            }
        }

        public async Task<List<Member>> GetMembersOfProject(long projectId)
        {
            var query = @"select m.MemberId, m.Name from ProjectMembers  pm
                        inner join Members m on pm.MemberId = m.MemberId
                        where ProjectId = @projectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryAsync<Member>(query, new { projectId = projectId });
                return result.ToList();
            }
        }

        public async Task DeleteProjectMembers(long projectId)
        {
            var query = @"delete from ProjectMembers where ProjectId = @projectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { projectId = projectId });
            }
        }
        public async Task DeleteProjectById(long projectId)
        {
            var query = @"delete from Projects where ProjectId = @projectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { projectId = projectId });
            }
        }
        public async Task<long> InsertNewProject(Project newProject)
        {
            var query = @"insert into Projects (ProjectName, StatusId, Assignee, TypeId, StartDate, EndDate, Description)
                        values (@projectName, @statusId, @assignee, @typeId, @startDate, @endDate, @description) returning ProjectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.QueryFirstOrDefaultAsync<long>(query, new
                {
                    projectName = newProject.ProjectName,
                    statusId = newProject.StatusId,
                    assignee = newProject.Assignee,
                    typeId = newProject.TypeId,
                    startDate = newProject.StartDate,
                    endDate = newProject.EndDate,
                    description = newProject.Description
                });
                return result;
            }
        }
        public async Task UpdateProject(Project updatedProject)
        {
            var query = @"update Projects 
                        set ProjectName = @projectName, StatusId = @statusId, Assignee = @assignee, TypeId = @typeId, 
                        StartDate = @startDate, EndDate = @endDate, Description = @description
                        where ProjectId = @projectId";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new
                {
                    projectId = updatedProject.ProjectId,
                    projectName = updatedProject.ProjectName,
                    statusId = updatedProject.StatusId,
                    assignee = updatedProject.Assignee,
                    typeId = updatedProject.TypeId,
                    startDate = updatedProject.StartDate,
                    endDate = updatedProject.EndDate,
                    description = updatedProject.Description
                });
            }
        }

        public async Task DeleteProjectMembersNotInProject(long projectId, List<long> members)
        {
            var query = $@"delete from ProjectMembers where MemberId not in ({string.Join(",", members)})";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { projectId = projectId });
            }
        }
        public async Task InsertProjectMembers(long projectId, List<long> members)
        {
            var query = $@"insert into ProjectMembers 
                            select @projectId, MemberId from Members 
                            where memberId in ({string.Join(",", members)}) 
                            and MemberId not in (select MemberId from ProjectMembers where ProjectId = @projectId)";
            using (var connection = _sqlProvider.GetDbConnectionMain())
            {
                var result = await connection.ExecuteAsync(query, new { projectId = projectId });
            }
        }
    }
}
