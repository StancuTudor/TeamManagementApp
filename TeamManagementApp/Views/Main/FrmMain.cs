using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Utils;
using TeamManagementApp.Views;
using TeamManagementApp.Views.Main;
using TeamManagementApp.Views.Members;
using TeamManagementApp.Views.MembersClasses;
using TeamManagementApp.Views.Projects;
using TeamManagementApp.Views.Types;
using TeamManagementApp.Views.Users;

namespace TeamManagementApp
{
    public partial class FrmMain : BaseView, IMainView
    {
        #region Properties
        public ICommonTextBox TxtProjectFilter { get; set; }
        public ICommonComboBox<Member, long> CmbAssigneeFilter { get; set; }
        public ICommonComboBox<ProjectStatus, long> CmbStatusFilter { get; set; }
        public ICommonComboBox<ProjectType, long> CmbTypeFilter { get; set; }
        public ICommonDataGridView<DisplayedProject> DgvProjects { get; set; }
        public string LblLoggedInUserText { get => lblLoggedInUser.Text.ValueOrEmptyIfNull(); set => lblLoggedInUser.Text = value; }
        public string LblConnectedServerText { get => lblConnectedServer.Text.ValueOrEmptyIfNull(); set => lblConnectedServer.Text = value; }
        public string LblAppVersionText { get => lblAppVersion.Text.ValueOrEmptyIfNull(); set => lblAppVersion.Text = value; }
        #endregion

        private readonly List<Form> _openForms = new List<Form>();
        private readonly IViewFactory _viewFactory;
        private readonly Size differenceBetweenFormAndMainPanel;
        private readonly Size differenceBetweenMainPanelAndDGV;
        public MainPresenter Presenter { get; private set; }
        public FrmMain(MainPresenter presenter, IViewFactory viewFactory)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
            _viewFactory = viewFactory;

            differenceBetweenFormAndMainPanel = (this.Size - pnlProjects.Size);
            differenceBetweenMainPanelAndDGV = (pnlProjects.Size - dgvProjects.Size);
        }

        private void InitializeWrappers()
        {
            TxtProjectFilter = new WinWrapperTextBox(txtProjectFilter);
            CmbAssigneeFilter = new WinWrapperComboBox<Member, long>(cmbAssigneeFilter, nameof(Member.Name), nameof(Member.MemberId));
            CmbStatusFilter = new WinWrapperComboBox<ProjectStatus, long>(cmbStatusFilter, nameof(ProjectStatus.Status), nameof(ProjectStatus.StatusId));
            CmbTypeFilter = new WinWrapperComboBox<ProjectType, long>(cmbTypeFilter, nameof(ProjectType.Type), nameof(ProjectType.TypeId));
            DgvProjects = new WinWrapperDataGridView<DisplayedProject>(dgvProjects);
        }

        #region Opening other forms
        public void CreateOrOpenForm(Form form)
        {
            if (CheckIfFormIsOpen(form, out var formOpen))
            {
                form.Close();

                formOpen.BringToFront();
                formOpen.Focus();
            }
            else
            {
                var newTab = new TabPage(form.Text) { Name = form.Text };

                newTab.Tag = form;

                _openForms.Add(form);

                form.BringToFront();

                form.FormClosing += Form_FormClosing;
                form.FormClosed += FormOnClose;

                form.Show();
                form.Focus();
            }
        }
        private bool CheckIfFormIsOpen(Form formToFind, out Form outForm)
        {
            outForm = _openForms.FirstOrDefault(form => form.Text == formToFind.Text);

            if (outForm != null)
            {
                if (formToFind.Tag is null || formToFind.Tag.Equals(outForm.Tag))
                    return true;
            }

            return false;
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            var frm = sender as Form;
            if (e.Cancel)
                return;

            // Bug in winforms: setting MdiParent will store the form reference in a list
            // internal to the mdi container. Closing the form will not clear that reference.
            // Property ParentInternal in
            // https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/Control.cs,ef716beee4738662
            // has issues: setting it to null (with MdiParent=null) will trigger a show/paint event of the form
            // which will bring back the closing form to view and will also delay the closing
            // while at the same time freezing the UI because all the controls must be recreated
            if (frm.MdiParent != null)
            {
                List<Tuple<Form, int>> indexes = new List<Tuple<Form, int>>();

                foreach (Control form in MdiParent.Controls[0].Controls)
                {
                    if (form is MdiClient) continue;
                    if (form is FrmMain) continue;
                    if (!(form is Form)) continue;

                    indexes.Add(Tuple.Create((Form)form, MdiParent.Controls[0].Controls.GetChildIndex(form)));
                }

                // Lowest index is the most visible window
                var activeChildren = indexes.Where(el => el.Item1 != frm && el.Item1.Visible).OrderBy(el => el.Item2).ToList();

                // Avoid MdiParent=null and directly remove the leaking reference
                frm.MdiParent.Controls[0].Controls.Remove(frm);

                // Bring back last visible window
                if (activeChildren.Any())
                    activeChildren[0].Item1.Focus();
            }
        }
        private async void FormOnClose(object sender, FormClosedEventArgs e)
        {
            var frm = sender as Form;
            _openForms.Remove(frm);

            await Presenter.RefreshFilters();
            await Presenter.RefreshProjectsList();
        }
        #endregion

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            pnlProjects.Size = this.Size - differenceBetweenFormAndMainPanel;
            dgvProjects.Size = pnlProjects.Size - differenceBetweenMainPanelAndDGV;
        }

        private async void btnApplyFilters_Click(object sender, EventArgs e)
        {
            await Presenter.ApplyFilters();
        }

        private async void btnAddToList_Click(object sender, EventArgs e)
        {
            await Presenter.AddToList();
        }

        private async void txtProjectFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                await Presenter.AddToList();
        }

        private void btnEmptyList_Click(object sender, EventArgs e)
        {
            Presenter.EmptyList();
        }

        private async void btnRefreshFilters_Click(object sender, EventArgs e)
        {
            await Presenter.RefreshFilters();
        }

        private async void btnRefreshList_Click(object sender, EventArgs e)
        {
            await Presenter.RefreshProjectsList();
        }

        private void mnuConfigMembers_Click(object sender, EventArgs e)
        {
            var frmMembers = _viewFactory.Create<FrmMembers>();
            CreateOrOpenForm(frmMembers);
        }

        private void mnuConfigProjectTypes_Click(object sender, EventArgs e)
        {
            var frmTypes = _viewFactory.Create<FrmTypes>();
            CreateOrOpenForm(frmTypes);
        }

        private void mnuConfigMemberClasses_Click(object sender, EventArgs e)
        {
            var frmMemberClasses = _viewFactory.Create<FrmMemberClasses>();
            CreateOrOpenForm(frmMemberClasses);
        }

        private void mnuAddProject_Click(object sender, EventArgs e)
        {
            var frmProjects = _viewFactory.Create<FrmProjects>();
            frmProjects.Presenter.ProjectFormType = FormType.New;
            CreateOrOpenForm(frmProjects);
        }

        private void dgvProjects_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var frmProjects = _viewFactory.Create<FrmProjects>();
            frmProjects.Presenter.ProjectFormType = FormType.Edit;
            frmProjects.Presenter.CurrentProject.ProjectId = DgvProjects.DataSource[e.RowIndex].ProjectId;
            CreateOrOpenForm(frmProjects);
        }

        private void mnuConfigUsers_Click(object sender, EventArgs e)
        {
            var frmUsers = _viewFactory.Create<FrmUsers>();
            CreateOrOpenForm(frmUsers);
        }
    }
}
