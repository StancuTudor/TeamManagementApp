using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Repositories;
using TeamManagementApp.Views.Main;

namespace TeamManagementApp.Services
{
    public interface IMainService
    {
        Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter);
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
                conditions.Add($"{assigneeColumn} in @assignees");
            }
            if (filter.AssigneeSelection == Selection.Null)
            {
                conditions.Add($"{assigneeColumn} is null");
            }
            if (filter.StatusSelection == Selection.Specific)
            {
                conditions.Add($"{statusColumn} in @statuses");
            }
            if (filter.TypeSelection == Selection.Specific)
            {
                conditions.Add($"{typeColumn} in @types");
            }
            return conditions;
        }
    }
}
