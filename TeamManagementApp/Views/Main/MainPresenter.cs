using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Services;

namespace TeamManagementApp.Views.Main
{
    public class MainPresenter
    {
        private IMainView _view;
        private readonly ICommonService _commonService;
        private readonly IMainService _mainService;
        private readonly IViewFactory _viewFactory;
        private readonly ICurrentUserService _currentUserService;
        private BindingList<DisplayedProject> _sourceDgvProjects;

        public MainPresenter(ICommonService commonService, IMainService mainService, IViewFactory viewFactory, ICurrentUserService currentUserService)
        {
            _commonService = commonService;
            _mainService = mainService;
            _viewFactory = viewFactory;
            _currentUserService = currentUserService;
            _sourceDgvProjects = new BindingList<DisplayedProject>();
        }
        public void SetView(IMainView view)
        {
            _view = view;
            SetDataGridViewProperties();
        }

        private void SetDataGridViewProperties()
        {
            var projectNameColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(DisplayedProject.Project),
                HeaderText = "Project",
                Width = 250,
                ReadOnly = true
            };
            _view.DgvProjects.AddColumn(projectNameColumn);
            var assigneeColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(DisplayedProject.Assignee),
                HeaderText = "Assignee",
                Width = 100,
                ReadOnly = true
            };
            _view.DgvProjects.AddColumn(assigneeColumn);
            var statusColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(DisplayedProject.Status),
                HeaderText = "Status",
                Width = 100,
                ReadOnly = true
            };
            _view.DgvProjects.AddColumn(statusColumn);
            var typeColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(DisplayedProject.Type),
                HeaderText = "Type",
                Width = 100,
                ReadOnly = true
            };
            _view.DgvProjects.AddColumn(typeColumn);
            var startDateColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(DisplayedProject.StartDate),
                HeaderText = "Start date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                ReadOnly = true
            };
            _view.DgvProjects.AddColumn(startDateColumn);
            var endDateColumn = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(DisplayedProject.EndDate),
                HeaderText = "End date",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy" },
                ReadOnly = true
            };
            _view.DgvProjects.AddColumn(endDateColumn);

            _view.DgvProjects.DataSource = _sourceDgvProjects;
        }

        public async Task FormLoad()
        {
            await InitializeFilters();
            await InitializeListForCurrentUser();
        }

        private async Task InitializeFilters()
        {
            await InitializeAssignees();
            await InitializeStatuses();
            await InitializeTypes();
        }
        private async Task InitializeListForCurrentUser()
        {
            if (_currentUserService.MemberId == null)
                return;
            ProjectFilter filter = new ProjectFilter()
            {
                AssigneeSelection = Selection.Specific,
                Assignees = [_currentUserService.MemberId.Value],
                StatusSelection = Selection.Specific,
                Statuses = [0,1,2] // Not started, In works, In progress
            };

            var filteredProjects = await _mainService.GetFilteredProjects(filter);
            foreach (var project in filteredProjects)
            {
                _sourceDgvProjects.Add(new DisplayedProject(project));
            }
        }

        private async Task InitializeAssignees()
        {
            var members = new List<Member>
            {
                new Member()
                {
                    Name = $"({Selection.Any.ToString()})",
                    MemberId = (int)Selection.Any
                },
                new Member()
                {
                    Name = "(Unassigned)",
                    MemberId = (int)Selection.Null
                }
            };
            members.AddRange(await _commonService.GetAllMembers());

            _view.CmbAssigneeFilter.DataSource = new BindingList<Member>(members);
        }
        
        private async Task InitializeStatuses()
        {
            var statuses = new List<ProjectStatus>
            {
                new ProjectStatus()
                {
                    Status = $"({Selection.Any.ToString()})",
                    StatusId = (int)Selection.Any
                }
            };
            statuses.AddRange(await _commonService.GetAllProjectStatuses());

            _view.CmbStatusFilter.DataSource = new BindingList<ProjectStatus>(statuses);
        }
        
        private async Task InitializeTypes()
        {
            var types = new List<ProjectType>
            {
                new ProjectType()
                {
                    Type = $"({Selection.Any.ToString()})",
                    TypeId = (int)Selection.Any
                }
            };
            types.AddRange(await _commonService.GetAllProjectTypes());

            _view.CmbTypeFilter.DataSource = new BindingList<ProjectType>(types);
        }

        private async Task<List<DetailedProject>> GetFilteredProjects()
        {
            var filter = GetProjectFilter();
            return await _mainService.GetFilteredProjects(filter);
        }
        private ProjectFilter GetProjectFilter()
        {
            Selection projectSelection;
            if (string.IsNullOrEmpty(_view.TxtProjectFilter.Text))
                projectSelection = Selection.Any;
            else
                projectSelection = Selection.Specific;

            var assigneeSelection = _view.CmbAssigneeFilter.SelectedValue switch
            {
                (int)Selection.Any => Selection.Any,
                (int)Selection.Null => Selection.Null,
                _ => Selection.Specific,
            };

            var statusSelection = _view.CmbStatusFilter.SelectedValue switch
            {
                (int)Selection.Any => Selection.Any,
                _ => Selection.Specific,
            };

            var typeSelection = _view.CmbTypeFilter.SelectedValue switch
            {
                (int)Selection.Any => Selection.Any,
                _ => Selection.Specific,
            };

            return new ProjectFilter()
            {
                ProjectSelection = projectSelection,
                Project = _view.TxtProjectFilter.Text,
                AssigneeSelection = assigneeSelection,
                Assignees = [_view.CmbAssigneeFilter.SelectedValue],
                StatusSelection = statusSelection,
                Statuses = [_view.CmbStatusFilter.SelectedValue],
                TypeSelection = typeSelection,
                Types = [_view.CmbTypeFilter.SelectedValue]
            };
        }

        public async Task ApplyFilters()
        {
            _sourceDgvProjects.Clear();
            var filteredProjects = await GetFilteredProjects();
            foreach (var project in filteredProjects)
            {
                _sourceDgvProjects.Add(new DisplayedProject(project));
            }
        }
        public async Task AddToList()
        {
            var filteredProjects = await GetFilteredProjects();
            foreach (var project in filteredProjects)
            {
                _sourceDgvProjects.Add(new DisplayedProject(project));
            }
        }
        public void EmptyList()
        {
            _sourceDgvProjects.Clear();
        }
        public async Task ResetFilters()
        {
            _view.TxtProjectFilter.Text = string.Empty;
            await InitializeFilters();
        }
    }
}
