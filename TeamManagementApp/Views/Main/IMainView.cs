using TeamManagementApp.Util.CommonControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;

namespace TeamManagementApp.Views.Main
{
    public interface IMainView
    {
        ICommonTextBox TxtProjectFilter { get; set; }
        ICommonComboBox<Member, int> CmbAssigneeFilter { get; set; }
        ICommonComboBox<ProjectStatus, int> CmbStatusFilter { get; set; }
        ICommonComboBox<ProjectType, int> CmbTypeFilter { get; set; }
        ICommonDataGridView<DisplayedProject> DgvProjects { get; set; }
    }
}
