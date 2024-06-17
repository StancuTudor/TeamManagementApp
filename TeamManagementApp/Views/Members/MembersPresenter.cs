using System.ComponentModel;
using TeamManagementApp.Models;
using TeamManagementApp.Services;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Views.Members
{
    public class MembersPresenter
    {
        private IMembersView _view;
        private readonly ICommonService _commonService;
        private readonly IMembersService _membersService;

        public MembersPresenter(ICommonService commonService, IMembersService membersService)
        {
            _commonService = commonService;
            _membersService = membersService;
        }
        public void SetView(IMembersView view)
        {
            _view = view;
        }

        public async Task FormLoad()
        {
            try
            {
                await InitializeControls();
            }
            catch (ValidationException ex)
            {
                CustomMessageBox.ShowWarning($"{ex.Message}\r\nYou can't open this menu.");
                _view.CloseForm();
            }
        }
        private async Task InitializeControls()
        {
            await InitializeMemberClasses();
            await InitializeUsers();
            await InitializeMembers();
        }
        private async Task InitializeMembers()
        {
            var members = new List<Member>
            {
                new Member()
                {
                    Name = $"({Selection.New.ToString()})",
                    MemberId = (long)Selection.New
                }
            };
            members.AddRange(await _commonService.GetAllMembers(ActiveSelection.All));

            _view.CmbMembers.DataSource = new BindingList<Member>(members);
        }
        private async Task InitializeMemberClasses()
        {
            var classes = await _commonService.GetAllMemberClasses(ActiveSelection.OnlyActive);
            if (classes.Count == 0)
                throw new ValidationException("There are no active member classes.");
            _view.CmbClass.DataSource = new BindingList<MemberClass>(classes);
        }
        private async Task InitializeUsers()
        {
            var users = new List<UserLogin>
            {
                new UserLogin()
                {
                    Username = "(No user)",
                    UserId = (long)Selection.Null
                }
            };
            users.AddRange(await _commonService.GetAllUsers());

            _view.CmbUser.DataSource = new BindingList<UserLogin>(users);
        }

        public void FillForSelectedMember()
        {
            var selectedMember = _view.CmbMembers.SelectedItem;
            if (selectedMember.MemberId == (long)Selection.New)
            {
                FillForNewMember();
            }
            else
            {
                FillForMember(selectedMember);
            }
        }

        private void FillForNewMember()
        {
            _view.TxtMemberDetails.Text = string.Empty;
            _view.CmbUser.SelectedIndex = 0;
            _view.CmbClass.SelectedIndex = 0;
            _view.ChkActive.Checked = true;
        }
        private void FillForMember(Member selectedMember)
        {
            _view.CmbClass.SelectedIndex = _view.CmbClass.DataSource.ToList().FindIndex(x => x.ClassId == selectedMember.ClassId);
            _view.CmbUser.SelectedIndex = _view.CmbUser.DataSource.ToList().FindIndex(x => GetValueOfUserCheck(x.UserId) == selectedMember.UserId);
            _view.ChkActive.Checked = selectedMember.Active;
            _view.TxtMemberDetails.Text = selectedMember.Name;
        }
        private long? GetValueOfUserCheck(long userId)
        {
            if (userId == (long)Selection.Null)
                return null;
            return userId;
        }

        public async Task DeleteMember()
        {
            try
            {
                var member = _view.CmbMembers.SelectedItem;
                if (member.MemberId == (long)Selection.New)
                    throw new InvalidOperationException("Invalid operation.");

                var result = CustomMessageBox.ShowQuestion($"Are you sure you want to delete {member.Name}?");
                if (result == DialogResult.Yes)
                    await DeleteMemberById(member.MemberId);
            }
            catch (InvalidOperationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }
        private async Task DeleteMemberById(long memberId)
        {
            await _membersService.DeleteMemberById(memberId);
            CustomMessageBox.ShowInfo("Member delete succesfully.");
            await InitializeMembers();
        }

        public async Task Save()
        {
            try
            {
                var memberId = _view.CmbMembers.SelectedValue;
                var newMember = GetMemberModelFromControls();
                if (memberId == (long)Selection.New)
                    await _membersService.InsertNewMember(newMember);
                else
                    await _membersService.UpdateMember(newMember);

                CustomMessageBox.ShowInfo("Member saved succesfully.");
                await InitializeMembers();
            }
            catch (ValidationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }

        private Member GetMemberModelFromControls()
        {
            if (_view.CmbClass.SelectedIndex == -1)
            {
                throw new ValidationException("Select a valid class.");
            }

            return new Member()
            {
                MemberId = _view.CmbMembers.SelectedValue == (long)Selection.New ? 0 : _view.CmbMembers.SelectedValue,
                Name = _view.TxtMemberDetails.Text.Trim(),
                Active = _view.ChkActive.Checked,
                ClassId = _view.CmbClass.SelectedValue,
                UserId = _view.CmbUser.SelectedValue == (long)Selection.Null ? null : _view.CmbUser.SelectedValue,
            };
        }
    }
}
