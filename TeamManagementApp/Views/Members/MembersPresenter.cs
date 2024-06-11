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
            await InitializeMembers();
            await InitializeMemberClasses();
            await InitializeUsers();
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
    }
}
