using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Members
{
    public interface IMembersView
    {
        ICommonComboBox<Member, int> CmbMembers { get; set; }
        ICommonTextBox TxtMemberDetails { get; set; }
        ICommonComboBox<MemberClass, int> CmbClass { get; set; }
        ICommonComboBox<UserLogin, int> CmbUser { get; set; }
        ICommonCheckBox ChkActive { get; set; }
    }
}
