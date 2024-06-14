using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Members
{
    public interface IMemberClassesView
    {
        ICommonComboBox<MemberClass, long> CmbMemberClasses { get; set; }
        ICommonTextBox TxtMemberClassDetails { get; set; }
        ICommonCheckBox ChkActive { get; set; }
    }
}
