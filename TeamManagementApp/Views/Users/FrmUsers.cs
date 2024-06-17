using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Users
{
    public partial class FrmUsers : BaseView, IUsersView
    {
        #region Properties
        public ICommonRadioButton RbNewUser { get; set; }
        public ICommonRadioButton RbUsername { get; set; }
        public ICommonRadioButton RbMember { get; set; }
        public ICommonComboBox<MemberAndUser, long> CmbSearchUsername { get; set; }
        public ICommonComboBox<MemberAndUser, long> CmbSearchMember { get; set; }
        public ICommonTextBox TxtUserUsername { get; set; }
        public ICommonComboBox<Member, long> CmbUserMember { get; set; }
        public ICommonButton BtnResetPassword { get; set; }
        public ICommonButton BtnDelete { get; set; }
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
            RbNewUser = new WinWrapperRadioButton(rbNewUser);
            RbUsername = new WinWrapperRadioButton(rbUsername);
            RbMember = new WinWrapperRadioButton(rbMember);
            CmbSearchUsername = new WinWrapperComboBox<MemberAndUser, long>(cmbSearchUsername, nameof(MemberAndUser.Username), nameof(MemberAndUser.UserId));
            CmbSearchMember = new WinWrapperComboBox<MemberAndUser, long>(cmbSearchMember, nameof(MemberAndUser.MemberName), nameof(MemberAndUser.UserId));
            TxtUserUsername = new WinWrapperTextBox(txtUserUsername);
            CmbUserMember = new WinWrapperComboBox<Member, long>(cmbUserMember, nameof(Member.Name), nameof(Member.MemberId));
            BtnResetPassword = new WinWrapperButton(btnResetPassword);
            BtnDelete = new WinWrapperButton(btnDelete);
        }

        private async void FrmUsers_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        private void rbNewUser_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.ManageSearchGroup();
        }

        private void rbUsername_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.ManageSearchGroup();
        }

        private void rbMember_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.ManageSearchGroup();
        }

        private void cmbSearchUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.FillForSelectedUser();
        }

        private void cmbSearchMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.FillForSelectedUser();
        }
    }
}
