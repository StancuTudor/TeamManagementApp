using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Users
{
    public interface IUsersView
    {
        ICommonRadioButton RbNewUser { get; set; }
        ICommonRadioButton RbUsername { get; set; }
        ICommonRadioButton RbMember { get; set; }
        ICommonComboBox<MemberAndUser, long> CmbSearchUsername { get; set; }
        ICommonComboBox<MemberAndUser, long> CmbSearchMember { get; set; }
        ICommonTextBox TxtUserUsername { get; set; }
        ICommonComboBox<Member, long> CmbUserMember { get; set; }
        ICommonButton BtnResetPassword { get; set; }
        ICommonButton BtnDelete { get; set; }
    }
}
