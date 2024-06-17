using TeamManagementApp.Repositories;

namespace TeamManagementApp.Services
{
    public interface IUsersService
    {
    }
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


    }
}
