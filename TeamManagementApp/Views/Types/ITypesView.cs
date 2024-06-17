using TeamManagementApp.Models;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Types
{
    public interface ITypesView
    {
        ICommonComboBox<ProjectType, long> CmbTypes { get; set; }
        ICommonTextBox TxtTypeDetails { get; set; }
        ICommonCheckBox ChkActive { get; set; }
    }
}
