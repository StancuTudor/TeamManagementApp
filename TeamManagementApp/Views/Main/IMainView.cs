using TeamManagementApp.Models;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Main
{
    public interface IMainView
    {
        ICommonTextBox TxtProjectFilter { get; set; }
        ICommonComboBox<Member, long> CmbAssigneeFilter { get; set; }
        ICommonComboBox<ProjectStatus, long> CmbStatusFilter { get; set; }
        ICommonComboBox<ProjectType, long> CmbTypeFilter { get; set; }
        ICommonDataGridView<DisplayedProject> DgvProjects { get; set; }
        string LblLoggedInUserText { get; set; }
        string LblConnectedServerText { get; set; }
        string LblAppVersionText { get; set; }
    }
}
