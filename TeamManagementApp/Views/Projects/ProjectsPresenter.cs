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
        public Project CurrentProject = new Project();

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
                DisableUnwantedControls();
                await InitializeControls();
                await InitializeCurrentProject();
            }
            catch (ValidationException ex)
            {
                CustomMessageBox.ShowWarning($"{ex.Message}\r\nYou can't open this menu.");
                _view.CloseForm();
            }
        }

        private void DisableUnwantedControls()
        {
            if(ProjectFormType == FormType.New)
            {
                _view.BtnDelete.Enabled = false;
            }
            if(ProjectFormType == FormType.ViewOnly)
            {
                _view.BtnDelete.Enabled = false;
                _view.BtnSave.Enabled = false;
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
                // Validate if the project was deleted.
                Project? foundProject = await _projectsService.GetProjectDataById(CurrentProject.ProjectId);
                if (foundProject == null)
                {
                    throw new ValidationException("Project not found.");
                }
                CurrentProject = foundProject;

                _view.TxtProjectName.Text = foundProject.ProjectName;
                _view.CmbStatus.SelectedIndex = _view.CmbStatus.DataSource.ToList().FindIndex(x => x.StatusId == foundProject.StatusId);
                _view.CmbAssignee.SelectedIndex = _view.CmbAssignee.DataSource.ToList().FindIndex(x => GetValueOfMemberCheck(x.MemberId) == foundProject.Assignee);
                _view.CmbType.SelectedIndex = _view.CmbType.DataSource.ToList().FindIndex(x => x.TypeId == foundProject.TypeId);
                if (foundProject.StartDate == null)
                    _view.DtpStartDate.Checked = false;
                else
                    _view.DtpStartDate.Value = foundProject.StartDate.Value;
                if (foundProject.EndDate == null)
                    _view.DtpEndDate.Checked = false;
                else
                    _view.DtpEndDate.Value = foundProject.EndDate.Value;
                _view.RTxtDescription.Text = foundProject.Description;

                await InitializeMembers();
            }
        }
        private long? GetValueOfMemberCheck(long memberId)
        {
            if (memberId == (long)Selection.Null)
                return null;
            return memberId;
        }
        private async Task InitializeMembers()
        {
            var members = await _projectsService.GetMembersOfProject(CurrentProject.ProjectId);
            foreach (var member in members)
            {
                _view.LvwMembers.Add(member.Name, member.MemberId);
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

        public async Task Save()
        {
            try
            {
                var newProject = GetProjectFromControls();
                ValidateSaveProject(newProject);

                var memberList = GetMemberList();
                if (ProjectFormType == FormType.New)
                {
                    await _projectsService.InsertNewProject(newProject, memberList);
                }
                else
                {
                    await _projectsService.UpdateProject(newProject, memberList);
                }
                CustomMessageBox.ShowInfo("Project saved succesfully.");
                _view.CloseForm();
            }
            catch (ValidationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }

        private void ValidateSaveProject(Project newProject)
        {
            if (string.IsNullOrEmpty(newProject.ProjectName))
                throw new ValidationException("Project name can't be empty.");

            if (_view.DtpStartDate.Checked && _view.DtpEndDate.Checked)
                if (_view.DtpStartDate.Value > _view.DtpEndDate.Value)
                    throw new ValidationException("Incorrect period.");
        }

        private Project GetProjectFromControls()
        {
            return new Project()
            {
                ProjectId = CurrentProject.ProjectId,
                ProjectName = _view.TxtProjectName.Text,
                Assignee = _view.CmbAssignee.SelectedValue == (int)Selection.Null ? null : _view.CmbAssignee.SelectedValue,
                TypeId = _view.CmbType.SelectedValue = _view.CmbType.SelectedValue,
                StartDate = _view.DtpStartDate.Checked == false ? null : _view.DtpStartDate.Value,
                EndDate = _view.DtpEndDate.Checked == false ? null : _view.DtpEndDate.Value,
                Description = _view.RTxtDescription.Text,
                StatusId = _view.CmbStatus.SelectedValue,
            };
        }
        private List<long> GetMemberList()
        {
            var result = new List<long>();
            foreach (var it in _view.LvwMembers.Items)
            {
                result.Add(it.Tag);
            }
            return result;
        }

        public async Task Delete()
        {
            var validationResult = CustomMessageBox.ShowQuestion($"Are you sure you want to delete {CurrentProject.ProjectName}?");
            if (validationResult == DialogResult.Yes)
                await _projectsService.DeleteProjectById(CurrentProject.ProjectId);
            CustomMessageBox.ShowInfo("Project deleted succesfully.");
            _view.CloseForm();
        }

        private bool IsMemberInList(long memberId)
        {
            foreach (var it in _view.LvwMembers.Items)
                if (it.Tag == memberId)
                    return true;
            return false;
        }
        public void AddMember()
        {
            if (_view.CmbMember.SelectedIndex == -1)
                return;
            if (IsMemberInList(_view.CmbMember.SelectedValue))
                return;
            _view.LvwMembers.Add(_view.CmbMember.SelectedItem.Name, _view.CmbMember.SelectedValue);
        }
        public void RemoveAllMembers()
        {
            _view.LvwMembers.Clear();
        }
        public void RemoveMember()
        {
            while (_view.LvwMembers.SelectedItems.Count > 0)
            {
                var selectedIndex = _view.LvwMembers.SelectedItems[0].Index;
                _view.LvwMembers.Remove(selectedIndex);
            }
        }
    }
}
