using TeamManagementApp.Models;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Views.MembersClasses
{
    public interface IMemberClassesView
    {
        ICommonComboBox<MemberClass, long> CmbMemberClasses { get; set; }
        ICommonTextBox TxtMemberClassDetails { get; set; }
        ICommonCheckBox ChkActive { get; set; }
    }
}
