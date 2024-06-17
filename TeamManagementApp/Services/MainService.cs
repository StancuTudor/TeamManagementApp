using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Repositories;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Services
{
    public interface IMainService
    {
        ServerConfigModel GetServerConfig();
        Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter);
        Task<List<DetailedProject>> GetProjectsById(List<long> projectIds);
    }

    public class MainService : IMainService
    {
        private readonly IMainRepository _mainRepository;
        public MainService(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public ServerConfigModel GetServerConfig()
        {
            return _mainRepository.GetServerConfig();
        }
        public async Task<List<DetailedProject>> GetFilteredProjects(ProjectFilter filter)
        {
            var conditions = _mainRepository.GetProjectFilterConditions(filter);
            return await _mainRepository.GetFilteredProjects(filter, conditions);
        }
        public async Task<List<DetailedProject>> GetProjectsById(List<long> projectIds)
        {
            var result = new List<DetailedProject>();
            foreach (var projectId in projectIds)
            {
                var project = await _mainRepository.GetProjectById(projectId);
                if(project != null)
                    result.Add(project);
            }
            return result;
        }
    }
}
