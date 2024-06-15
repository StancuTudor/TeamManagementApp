using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Utils;
using TeamManagementApp.Utils.CommonControls;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Projects
{
    public partial class FrmProjects : BaseView, IProjectsView
    {
        #region Properties
        public FormType ProjectFormType { get; set; }
        public long CurrentProjectId { get; set; }
        public ICommonTextBox TxtProjectName { get; set; }
        public ICommonComboBox<ProjectStatus, long> CmbStatus { get; set; }
        public ICommonComboBox<Member, long> CmbAssignee { get; set; }
        public ICommonComboBox<ProjectType, long> CmbType { get; set; }
        public ICommonDateTimePicker DtpDateStart { get; set; }
        public ICommonDateTimePicker DtpDateEnd { get; set; }
        public ICommonRichTextBox RTxtDescription { get; set; }
        public ICommonComboBox<MemberClass, long> CmbMemberClass { get; set; }
        public ICommonComboBox<Member, long> CmbMember { get; set; }
        public ICommonListView<long> LvwMembers { get; set; }
        #endregion
        public ProjectsPresenter Presenter { get; private set; }
        public FrmProjects(ProjectsPresenter presenter)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
        }

        private void InitializeWrappers()
        {
            TxtProjectName = new WinWrapperTextBox(txtProjectName);
            CmbStatus = new WinWrapperComboBox<ProjectStatus, long>(cmbStatus, nameof(ProjectStatus.Status), nameof(ProjectStatus.StatusId));
            CmbAssignee = new WinWrapperComboBox<Member, long>(cmbAssignee, nameof(Member.Name), nameof(Member.MemberId));
            CmbType = new WinWrapperComboBox<ProjectType, long>(cmbType, nameof(ProjectType.Type), nameof(ProjectType.TypeId));
            DtpDateStart = new WinWrapperDateTimePicker(dtpDateStart);
            DtpDateEnd = new WinWrapperDateTimePicker(dtpDateEnd);
            RTxtDescription = new WinWrapperRichTextBox(rtxtDescription);
            CmbMemberClass = new WinWrapperComboBox<MemberClass, long>(cmbMemberClass, nameof(MemberClass.ClassName), nameof(MemberClass.ClassId));
            CmbMember = new WinWrapperComboBox<Member, long>(cmbMember, nameof(Member.Name), nameof(Member.MemberId));
            LvwMembers = new WinWrapperListView<long>(lvwMembers);
        }

        private async void FrmProjects_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateStart.Checked)
                dtpDateStart.CustomFormat = "dd.MM.yyyy";
            else
                dtpDateStart.CustomFormat = " ";
        }

        private void dtpDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateEnd.Checked)
                dtpDateEnd.CustomFormat = "dd.MM.yyyy";
            else
                dtpDateEnd.CustomFormat = " ";
        }

        private async void cmbMemberClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Presenter.SelectMembersByClass();
        }
    }
}
