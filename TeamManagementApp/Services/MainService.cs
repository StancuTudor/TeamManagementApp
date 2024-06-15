using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Repositories;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Services
{
    public interface IMainService
    {
        Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter);
        ServerConfigModel GetServerConfig();
    }

    public class MainService : IMainService
    {
        private readonly IMainRepository _mainRepository;
        public MainService(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }
        public async Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter)
        {
            var conditions = GetProjectFilterConditions(filter);
            return await _mainRepository.GetFilteredProjects(filter, conditions);
        }
        private List<string> GetProjectFilterConditions(ProjectFilter filter)
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

        public ServerConfigModel GetServerConfig()
        {
            return _mainRepository.GetServerConfig();
        }
    }
}
