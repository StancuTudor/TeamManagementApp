using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Members
{
    public interface IMembersView
    {
        ICommonComboBox<Member, long> CmbMembers { get; set; }
        ICommonTextBox TxtMemberDetails { get; set; }
        ICommonComboBox<MemberClass, long> CmbClass { get; set; }
        ICommonComboBox<UserLogin, long> CmbUser { get; set; }
        ICommonCheckBox ChkActive { get; set; }
        void CloseForm();
    }
}
