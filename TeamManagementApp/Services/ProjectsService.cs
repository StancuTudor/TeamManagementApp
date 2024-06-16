using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IProjectsService
    {
        Task<List<Member>> GetMembersByClassId(long classId);
        Task<Project?> GetProjectDataById(long projectId);
        Task<List<Member>> GetMembersOfProject(long projectId);
        Task DeleteProjectById(long projectId);
        Task InsertNewProject(Project newProject, List<long> members);
        Task UpdateProject(Project updatedProject, List<long> members);
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

        public async Task<List<Member>> GetMembersOfProject(long projectId)
        {
            return await _projectsRepository.GetMembersOfProject(projectId);
        }

        public async Task DeleteProjectById(long projectId)
        {
            await _projectsRepository.DeleteProjectMembers(projectId);
            await _projectsRepository.DeleteProjectById(projectId);
        }
        public async Task InsertNewProject(Project newProject, List<long> members)
        {
            newProject.ProjectId = await _projectsRepository.InsertNewProject(newProject);
            await ManageProjectMembers(newProject.ProjectId, members);
        }
        public async Task UpdateProject(Project updatedProject, List<long> members)
        {
            await _projectsRepository.UpdateProject(updatedProject);
            await ManageProjectMembers(updatedProject.ProjectId,  members);
        }
        private async Task ManageProjectMembers(long projectId, List<long> members)
        {
            await _projectsRepository.DeleteProjectMembersNotInProject(projectId, members);
            await _projectsRepository.InsertProjectMembers(projectId, members);
        }
    }
}
