using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IMemberClassesService
    {
        Task DeleteMemberClassById(long memberClassId);
        Task InsertNewMemberClass(MemberClass memberClass);
        Task UpdateMemberClass(MemberClass memberClass);
    }
    public class MemberClassesService : IMemberClassesService
    {
        private readonly IMemberClassesRepository _memberClassesRepository;
        public MemberClassesService(IMemberClassesRepository memberClassesRepository)
        {
            _memberClassesRepository = memberClassesRepository;
        }

        public async Task DeleteMemberClassById(long memberClassId)
        {
            try
            {
                await _memberClassesRepository.DeleteMemberClassById(memberClassId);
            }
            catch (Npgsql.PostgresException)
            {
                throw new InvalidOperationException("Can't delete member class. It's being used by a member.");
            }
        }

        public async Task InsertNewMemberClass(MemberClass memberClass)
        {
            await _memberClassesRepository.InsertNewMemberClass(memberClass);
        }

        public async Task UpdateMemberClass(MemberClass memberClass)
        {
            await _memberClassesRepository.UpdateMemberClass(memberClass);
        }
    }
}
