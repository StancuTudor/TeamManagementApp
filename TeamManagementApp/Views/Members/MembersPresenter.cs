using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Services;
using TeamManagementApp.Views.Main;

namespace TeamManagementApp.Views.Members
{
    public class MembersPresenter
    {
        private IMembersView _view;
        private readonly IMembersService _membersService;

        public MembersPresenter(IMembersService membersService)
        {
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

        }
        private async Task InitializeMemberClasses()
        {

        }
        private async Task InitializeUsers()
        {

        }
    }
}
