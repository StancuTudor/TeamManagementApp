using TeamManagementApp.Services;

namespace TeamManagementApp.Views.Users
{
    public class UsersPresenter
    {
        private IUsersView _view;
        private readonly ICommonService _commonService;
        private readonly IUsersService _usersService;

        public UsersPresenter(ICommonService commonService, IUsersService usersService)
        {
            _commonService = commonService;
            _usersService = usersService;
        }
        public void SetView(IUsersView view)
        {
            _view = view;
        }
    }
}
