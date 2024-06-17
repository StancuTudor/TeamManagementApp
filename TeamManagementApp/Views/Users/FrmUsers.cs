namespace TeamManagementApp.Views.Users
{
    public partial class FrmUsers : BaseView, IUsersView
    {
        #region Properties
        #endregion
        public UsersPresenter Presenter { get; private set; }
        public FrmUsers(UsersPresenter presenter)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
        }

        private void InitializeWrappers()
        {
        }
    }
}
