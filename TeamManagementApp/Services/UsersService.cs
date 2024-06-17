using TeamManagementApp.Models;
using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IUsersService
    {
        Task<List<MemberAndUser>> GetAllUsersUsername();
        Task<List<MemberAndUser>> GetAllUsersMember();
        Task ResetPasswordOfUser(long userId);
        Task DeleteUser(long userId);
        Task InsertNewUser(UserLogin userLogin);
        Task UpdateUser(UserLogin userLogin);
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
        public async Task ResetPasswordOfUser(long userId)
        {
            await _usersRepository.ResetPasswordOfUser(userId);
        }
        public async Task DeleteUser(long userId)
        {
            await _usersRepository.DeleteUser(userId);
        }
        public async Task InsertNewUser(UserLogin userId)
        {
            try
            {
                userId.UserId = await _usersRepository.InsertNewUser(userId);
                if (userId.MemberId != null)
                {
                    await _usersRepository.UpdateMemberUser(userId);
                }
            }
            catch (Npgsql.NpgsqlException)
            {
                throw new InvalidOperationException("Username already exists.");
            }
        }
        public async Task UpdateUser(UserLogin userId)
        {
            await _usersRepository.UpdateUser(userId);

            await _usersRepository.RemoveMemberUserId(userId.UserId);
            await _usersRepository.UpdateMemberUser(userId);
        }
    }
}
