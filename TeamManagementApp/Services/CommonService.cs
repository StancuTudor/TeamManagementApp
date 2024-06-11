using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface ICommonService
    {
        Task<List<Member>> GetAllMembers();
        Task<List<ProjectStatus>> GetAllProjectStatuses();
        Task<List<ProjectType>> GetAllProjectTypes();
        Task<List<UserLogin>> GetAllUsers();
        Task<List<MemberClass>> GetAllMemberClasses();
    }

    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _commonRepository.GetAllMembers();
        }
        public async Task<List<ProjectStatus>> GetAllProjectStatuses()
        {
            return await _commonRepository.GetAllProjectStatuses();
        }
        public async Task<List<ProjectType>> GetAllProjectTypes()
        {
            return await _commonRepository.GetAllProjectTypes();
        }
        public async Task<List<UserLogin>> GetAllUsers()
        {
            return await _commonRepository.GetAllUsers();
        }
        public async Task<List<MemberClass>> GetAllMemberClasses()
        {
            return await _commonRepository.GetAllMemberClasses();
        }
    }
}
