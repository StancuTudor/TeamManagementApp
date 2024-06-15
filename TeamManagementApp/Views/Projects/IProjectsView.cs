using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Utils;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Projects
{
    public interface IProjectsView
    {
        FormType ProjectFormType { get; set; }
        long CurrentProjectId { get; set; }
        ICommonTextBox TxtProjectName { get; set; }
        ICommonComboBox<ProjectStatus, long> CmbStatus { get; set; }
        ICommonComboBox<Member, long> CmbAssignee { get; set; }
        ICommonComboBox<ProjectType, long> CmbType { get; set; }
        ICommonDateTimePicker DtpDateStart { get; set; }
        ICommonDateTimePicker DtpDateEnd { get; set; }
        ICommonRichTextBox RTxtDescription { get; set; }
        ICommonComboBox<MemberClass, long> CmbMemberClass { get; set; }
        ICommonComboBox<Member, long> CmbMember { get; set; }
        ICommonListView<long> LvwMembers { get; set; }
        void CloseForm();
    }
}
