using System.ComponentModel;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Services;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Views.Projects
{
    public class ProjectsPresenter
    {
        private IProjectsView _view;
        private readonly ICommonService _commonService;
        private readonly IProjectsService _projectsService;
        public FormType ProjectFormType;
        public long CurrentProjectId;

        public ProjectsPresenter(ICommonService commonService, IProjectsService projectsService)
        {
            _commonService = commonService;
            _projectsService = projectsService;
        }
        public void SetView(IProjectsView view)
        {
            _view = view;
        }

        public async Task FormLoad()
        {
            try
            {
                await InitializeControls();
                await InitializeCurrentProject();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"{ex.Message}\r\nYou can't open this menu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _view.CloseForm();
            }
        }

        private async Task InitializeControls()
        {
            _view.DtpStartDate.Checked = false;
            _view.DtpStartDate.CustomFormat = " ";
            _view.DtpEndDate.Checked = false;
            _view.DtpEndDate.CustomFormat = " ";
            await InitializeStatuses();
            await InitializeAssignees();
            await InitializeTypes();
            await InitializeMemberClasses();
        }

        private async Task InitializeStatuses()
        {
            var statuses = await _commonService.GetAllProjectStatuses();

            _view.CmbStatus.DataSource = new BindingList<ProjectStatus>(statuses);
        }
        private async Task InitializeAssignees()
        {
            var members = new List<Member>
            {
                new Member()
                {
                    Name = $"(Unassigned)",
                    MemberId = (long)Selection.Null
                }
            };
            members.AddRange(await _commonService.GetAllMembers(ActiveSelection.OnlyActive));

            _view.CmbAssignee.DataSource = new BindingList<Member>(members);
        }
        private async Task InitializeTypes()
        {
            var types = await _commonService.GetAllProjectTypes(ActiveSelection.OnlyActive);
            if (types.Count == 0)
                throw new ValidationException("There are no active project types.");
            _view.CmbType.DataSource = new BindingList<ProjectType>(types);
        }
        private async Task InitializeMemberClasses()
        {
            var classes = new List<MemberClass>()
            {
                new MemberClass()
                {
                    ClassName = $"({Selection.Any})",
                    ClassId = (long)Selection.Any
                }
            };

            classes.AddRange(await _commonService.GetAllMemberClasses(ActiveSelection.OnlyActive));
            _view.CmbMemberClass.DataSource = new BindingList<MemberClass>(classes);
        }

        private async Task InitializeCurrentProject()
        {
            if (ProjectFormType == FormType.Edit || ProjectFormType == FormType.ViewOnly)
            {
                Project? projectToLoad = await _projectsService.GetProjectDataById(CurrentProjectId);
                if (projectToLoad == null)
                {
                    throw new ValidationException("Project not found.");
                }

                _view.TxtProjectName.Text = projectToLoad.ProjectName;
                _view.CmbStatus.SelectedIndex = _view.CmbStatus.DataSource.ToList().FindIndex(x => x.StatusId == projectToLoad.StatusId);
                _view.CmbAssignee.SelectedIndex = _view.CmbAssignee.DataSource.ToList().FindIndex(x => x.MemberId == projectToLoad.Assignee);
                _view.CmbType.SelectedIndex = _view.CmbType.DataSource.ToList().FindIndex(x => x.TypeId == projectToLoad.TypeId);
                if (projectToLoad.StartDate == null)
                    _view.DtpStartDate.Checked = false;
                else
                    _view.DtpStartDate.Value = projectToLoad.StartDate.Value;
                if (projectToLoad.EndDate == null)
                    _view.DtpEndDate.Checked = false;
                else
                    _view.DtpEndDate.Value = projectToLoad.EndDate.Value;
                _view.RTxtDescription.Text = projectToLoad.Description;
            }
        }

        public async Task SelectMembersByClass()
        {
            var selectedClassId = _view.CmbMemberClass.SelectedValue;
            if(selectedClassId == (long)Selection.Any)
            {
                var members = await _commonService.GetAllMembers(ActiveSelection.OnlyActive);

                _view.CmbMember.DataSource = new BindingList<Member>(members);
            }
            else
            {
                var members = await _projectsService.GetMembersByClassId(selectedClassId);

                _view.CmbMember.DataSource = new BindingList<Member>(members);
            }
        }
    }
}
