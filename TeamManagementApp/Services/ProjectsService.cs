using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IProjectsService
    {
        Task<List<Member>> GetMembersByClassId(long classId);
        Task<Project?> GetProjectDataById(long projectId);
    }
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<List<Member>> GetMembersByClassId(long classId)
        {
            return await _projectsRepository.GetMembersByClassId(classId);
        }

        public async Task<Project?> GetProjectDataById(long projectId)
        {
            return await _projectsRepository.GetProjectDataById(projectId);
        }
    }
}
