using System.ComponentModel;
using TeamManagementApp.Models;
using TeamManagementApp.Services;
using TeamManagementApp.Utils;

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

        public async Task FormLoad()
        {
            await InitializeControls();
        }

        private async Task InitializeControls()
        {
            await InitializeUserMembers();
            await InitializeSearchUsers();
            await InitializeSearchMembers();

            _view.RbNewUser.Checked = true;
        }

        private async Task InitializeSearchUsers()
        {
            var users = await _usersService.GetAllUsersUsername();
            if (users.Count == 0)
                _view.RbUsername.Enabled = false;
            _view.CmbSearchUsername.DataSource = new BindingList<MemberAndUser>(users);
        }

        private async Task InitializeSearchMembers()
        {
            var users = await _usersService.GetAllUsersMember();
            if (users.Count == 0)
                _view.RbMember.Enabled = false;
            _view.CmbSearchMember.DataSource = new BindingList<MemberAndUser>(users);
        }

        private async Task InitializeUserMembers()
        {
            var members = new List<Member>
            {
                new Member()
                {
                    Name = $"(Unassigned)",
                    MemberId = (long)Selection.Null
                }
            };
            members.AddRange(await _commonService.GetAllMembers(ActiveSelection.All));

            _view.CmbUserMember.DataSource = new BindingList<Member>(members);
        }

        public void ManageSearchGroup()
        {
            if (_view.RbNewUser.Checked)
            {
                _view.BtnResetPassword.Enabled = false;
                _view.BtnDelete.Enabled = false;
                _view.CmbSearchUsername.SelectedIndex = -1;
                _view.CmbSearchUsername.Enabled = false;
                _view.CmbSearchMember.SelectedIndex = -1;
                _view.CmbSearchMember.Enabled = false;
            }
            if (_view.RbUsername.Checked)
            {
                _view.BtnResetPassword.Enabled = true;
                _view.BtnDelete.Enabled = true;
                _view.CmbSearchUsername.SelectedIndex = 0;
                _view.CmbSearchUsername.Enabled = true;
                _view.CmbSearchMember.SelectedIndex = -1;
                _view.CmbSearchMember.Enabled = false;
            }
            if (_view.RbMember.Checked)
            {
                _view.BtnResetPassword.Enabled = true;
                _view.BtnDelete.Enabled = true;
                _view.CmbSearchUsername.SelectedIndex = -1;
                _view.CmbSearchUsername.Enabled = false;
                _view.CmbSearchMember.SelectedIndex = 0;
                _view.CmbSearchMember.Enabled = true;
            }

            FillForSelectedUser();
        }

        public void FillForSelectedUser()
        {
            if (_view.RbNewUser.Checked)
            {
                FillForNewUser();
            }
            if(_view.RbUsername.Checked && _view.CmbSearchUsername.SelectedIndex != -1)
            {
                var selectedUser = _view.CmbSearchUsername.SelectedItem;
                FillForSelectedUser(selectedUser);
            }
            if(_view.RbMember.Checked && _view.CmbSearchMember.SelectedIndex != -1)
            {
                var selectedUser = _view.CmbSearchMember.SelectedItem;
                FillForSelectedUser(selectedUser);
            }
        }

        private void FillForNewUser()
        {
            _view.TxtUserUsername.Text = string.Empty;
            _view.CmbUserMember.SelectedIndex = 0;
        }
        private void FillForSelectedUser(MemberAndUser selectedUser)
        {
            _view.TxtUserUsername.Text = selectedUser.Username;
            _view.CmbUserMember.SelectedIndex = _view.CmbUserMember.DataSource.ToList().FindIndex(x => GetValueOfMemberCheck(x.MemberId) == selectedUser.MemberId);
        }
        private long? GetValueOfMemberCheck(long memberId)
        {
            if (memberId == (long)Selection.Null)
                return null;
            return memberId;
        }

        private MemberAndUser GetSelectedUser()
        {
            if (_view.RbNewUser.Checked)
            {
                return new MemberAndUser() { UserId = (long)Selection.New };
            }
            if(_view.RbUsername.Checked)
            {
                if(_view.CmbSearchUsername.SelectedIndex == -1)
                    throw new ValidationException("User not selected.");
                return _view.CmbSearchUsername.SelectedItem;
            }
            if(_view.RbMember.Checked)
            {
                if(_view.CmbSearchMember.SelectedIndex == -1)
                    throw new ValidationException("User not selected.");
                return _view.CmbSearchMember.SelectedItem;
            }
            throw new ValidationException("Invalid selection.");
        }
        public async Task ResetPasswordOfUser()
        {
            try
            {
                var selectedUser = GetSelectedUser();
                var validateResult = CustomMessageBox.ShowQuestion($"Are you sure you want to delete {selectedUser.Username}?");
                if (validateResult == DialogResult.Yes)
                    await _usersService.ResetPasswordOfUser(selectedUser.UserId);
                CustomMessageBox.ShowInfo("Password reset succesfully.");
            }
            catch(ValidationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }

        public async Task DeleteUser()
        {
            try
            {
                var selectedUser = GetSelectedUser();
                var validateResult = CustomMessageBox.ShowQuestion($"Are you sure you want to delete {selectedUser.Username}?");
                if(validateResult == DialogResult.Yes)
                    await _usersService.DeleteUser(selectedUser.UserId);
                CustomMessageBox.ShowInfo("User deleted succesfully.");
                await InitializeControls();
            }
            catch (ValidationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }
        private UserLogin GetUserModelFromControls()
        {
            var selectedUser = GetSelectedUser();
            selectedUser.Username = _view.TxtUserUsername.Text;
            selectedUser.MemberId = _view.CmbUserMember.SelectedValue == (long)Selection.Null ? null : _view.CmbUserMember.SelectedValue;
            return selectedUser;
        }
        public async Task SaveUser()
        {
            try
            {
                var newUser = GetUserModelFromControls();
                if(newUser.UserId == (long)Selection.New)
                    await _usersService.InsertNewUser(newUser);
                else
                    await _usersService.UpdateUser(newUser);
                CustomMessageBox.ShowInfo("User saved succesfully.");
                await InitializeControls();
            }
            catch (ValidationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }
    }
}
