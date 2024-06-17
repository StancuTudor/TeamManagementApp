using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IUsersService
    {
        Task<List<MemberAndUser>> GetAllUsersUsername();
        Task<List<MemberAndUser>> GetAllUsersMember();
    }
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<MemberAndUser>> GetAllUsersUsername()
        {
            return await _usersRepository.GetAllUsersUsername();
        }
        public async Task<List<MemberAndUser>> GetAllUsersMember()
        {
            return await _usersRepository.GetAllUsersMember();
        }
    }
}
