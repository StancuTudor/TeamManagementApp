using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IMembersService
    {
        Task DeleteMemberById(long memberId);
        Task InsertNewMember(Member member);
        Task UpdateMember(Member member);
    }
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IUsersRepository _usersRepository;
        public MembersService(IMembersRepository membersRepository, IUsersRepository usersRepository)
        {
            _membersRepository = membersRepository;
            _usersRepository = usersRepository;
        }

        public async Task DeleteMemberById(long memberId)
        {
            try
            {
                await _membersRepository.DeleteMemberById(memberId);
            }
            catch (Npgsql.PostgresException)
            {
                throw new InvalidOperationException("Can't delete member. It's being used in a project.");
            }
        }

        public async Task InsertNewMember(Member member)
        {
            if (member.UserId != null)
                await _usersRepository.RemoveMemberUserId(member.UserId.Value);
            await _membersRepository.InsertNewMember(member);
        }

        public async Task UpdateMember(Member member)
        {
            if (member.UserId != null)
                await _usersRepository.RemoveMemberUserId(member.UserId.Value);
            await _membersRepository.UpdateMember(member);
        }
    }
}
