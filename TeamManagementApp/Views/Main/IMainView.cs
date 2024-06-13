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
        ICommonComboBox<Member, long> CmbAssigneeFilter { get; set; }
        ICommonComboBox<ProjectStatus, long> CmbStatusFilter { get; set; }
        ICommonComboBox<ProjectType, long> CmbTypeFilter { get; set; }
        ICommonDataGridView<DisplayedProject> DgvProjects { get; set; }
    }
}
