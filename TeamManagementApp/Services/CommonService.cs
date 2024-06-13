using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Repositories;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Services
{
    public interface ICommonService
    {
        Task<List<Member>> GetAllMembers(ActiveSelection active);
        Task<List<ProjectStatus>> GetAllProjectStatuses();
        Task<List<ProjectType>> GetAllProjectTypes(ActiveSelection active);
        Task<List<UserLogin>> GetAllUsers();
        Task<List<MemberClass>> GetAllMemberClasses(ActiveSelection active);
    }

    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<List<Member>> GetAllMembers(ActiveSelection active)
        {
            return await _commonRepository.GetAllMembers(active);
        }
        public async Task<List<ProjectStatus>> GetAllProjectStatuses()
        {
            return await _commonRepository.GetAllProjectStatuses();
        }
        public async Task<List<ProjectType>> GetAllProjectTypes(ActiveSelection active)
        {
            return await _commonRepository.GetAllProjectTypes(active);
        }
        public async Task<List<UserLogin>> GetAllUsers()
        {
            return await _commonRepository.GetAllUsers();
        }
        public async Task<List<MemberClass>> GetAllMemberClasses(ActiveSelection active)
        {
            return await _commonRepository.GetAllMemberClasses(active);
        }
    }
}
