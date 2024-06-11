using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Models;
using TeamManagementApp.Services;
using TeamManagementApp.Views.Main;

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
            await InitializeControls();
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
                    MemberId = (int)Selection.New
                }
            };
            members.AddRange(await _commonService.GetAllMembers());

            _view.CmbMembers.DataSource = new BindingList<Member>(members);
        }
        private async Task InitializeMemberClasses()
        {
            var classes = await _commonService.GetAllMemberClasses();

            _view.CmbClass.DataSource = new BindingList<MemberClass>(classes);
        }
        private async Task InitializeUsers()
        {
            var users = new List<UserLogin>
            {
                new UserLogin()
                {
                    UserName = "(No user)",
                    UserId = (int)Selection.Null
                }
            };
            users.AddRange(await _commonService.GetAllUsers());

            _view.CmbUser.DataSource = new BindingList<UserLogin>(users);
        }

        public void FillForSelectedMember()
        {
            var selectedMember = _view.CmbMembers.SelectedItem;
            if(selectedMember.MemberId == (int)Selection.New)
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
        private int? GetValueOfUserCheck(int userId)
        {
            if (userId == (int)Selection.Null)
                return null;
            return userId;
        }

        public async Task DeleteMember()
        {
            try
            {
                var member = _view.CmbMembers.SelectedItem;
                if (member.MemberId == (int)Selection.New)
                    throw new InvalidOperationException("Invalid operation.");

                var result = MessageBox.Show($"Are you sure you want to delete {member.Name}?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    await DeleteMemberById(member.MemberId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
        private async Task DeleteMemberById(int memberId)
        {
            await _membersService.DeleteMemberById(memberId);
            await InitializeMembers();
            MessageBox.Show("Member delete succesfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public async Task Save()
        {
            var memberId = _view.CmbMembers.SelectedValue;
            var newMember = GetMemberModelFromControls();
            if (memberId == (int)Selection.New)
                await _membersService.InsertNewMember(newMember);
            else
                await _membersService.UpdateMember(newMember);

            await InitializeMembers();
            MessageBox.Show("Member saved succesfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Member GetMemberModelFromControls()
        {
            return new Member()
            {
                MemberId = _view.CmbMembers.SelectedValue == (int)Selection.New ? 0 : _view.CmbMembers.SelectedValue,
                Name = _view.TxtMemberDetails.Text.Trim(),
                Active = _view.ChkActive.Checked,
                ClassId = _view.CmbClass.SelectedValue,
                UserId = _view.CmbUser.SelectedValue == (int)Selection.Null ? null : _view.CmbUser.SelectedValue,
            };
        }
    }
}
