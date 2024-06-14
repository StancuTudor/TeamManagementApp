using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Members
{
    public interface ITypesView
    {
        ICommonComboBox<ProjectType, long> CmbTypes { get; set; }
        ICommonTextBox TxtTypeDetails { get; set; }
        ICommonCheckBox ChkActive { get; set; }
    }
}
