namespace TeamManagementApp.Repositories
{
    public interface IUsersRepository
    {
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly ISqlServerConnectionProvider _sqlProvider;
        public UsersRepository(ISqlServerConnectionProvider sqlProvider)
        {
            _sqlProvider = sqlProvider;
        }
    }
}
