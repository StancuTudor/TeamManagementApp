using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Projects
{
    public interface IProjectsView
    {
        ICommonTextBox TxtProjectName { get; set; }
        ICommonComboBox<ProjectStatus, long> CmbStatus { get; set; }
        ICommonComboBox<Member, long> CmbAssignee { get; set; }
        ICommonComboBox<ProjectType, long> CmbType { get; set; }
        ICommonDateTimePicker DtpStartDate { get; set; }
        ICommonDateTimePicker DtpEndDate { get; set; }
        ICommonRichTextBox RTxtDescription { get; set; }
        ICommonComboBox<MemberClass, long> CmbMemberClass { get; set; }
        ICommonComboBox<Member, long> CmbMember { get; set; }
        ICommonListView<long> LvwMembers { get; set; }
        ICommonButton BtnDelete { get; set; }
        ICommonButton BtnSave { get; set; }
        void CloseForm();
    }
}
