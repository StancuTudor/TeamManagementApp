using System.ComponentModel;
using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Views;
using TeamManagementApp.Views.Main;
using TeamManagementApp.Views.Members;

namespace TeamManagementApp
{
    public partial class FrmMain : BaseView, IMainView
    {
        #region Properties
        public ICommonTextBox TxtProjectFilter { get; set; }
        public ICommonComboBox<Member, int> CmbAssigneeFilter { get; set; }
        public ICommonComboBox<ProjectStatus, int> CmbStatusFilter { get; set; }
        public ICommonComboBox<ProjectType, int> CmbTypeFilter { get; set; }
        public ICommonDataGridView<DisplayedProject> DgvProjects { get; set; }
        #endregion

        private readonly List<Form> _openForms = new List<Form>();
        private readonly IViewFactory _viewFactory;
        public MainPresenter Presenter { get; private set; }
        public FrmMain(MainPresenter presenter, IViewFactory viewFactory)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
            _viewFactory = viewFactory;
        }

        private void InitializeWrappers()
        {
            TxtProjectFilter = new WinWrapperTextBox(txtProjectFilter);
            CmbAssigneeFilter = new WinWrapperComboBox<Member, int>(cmbAssigneeFilter, nameof(Member.Name), nameof(Member.MemberId));
            CmbStatusFilter = new WinWrapperComboBox<ProjectStatus, int>(cmbStatusFilter, nameof(ProjectStatus.Status), nameof(ProjectStatus.StatusId));
            CmbTypeFilter = new WinWrapperComboBox<ProjectType, int>(cmbTypeFilter, nameof(ProjectType.Type), nameof(ProjectType.TypeId));
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
            if (outForm is null)
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
        private void FormOnClose(object sender, FormClosedEventArgs e)
        {
            var frm = sender as Form;
            _openForms.Remove(frm);
        }
        #endregion

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        private async void btnApplyFilters_Click(object sender, EventArgs e)
        {
            await Presenter.ApplyFilters();
        }

        private async void btnAddToList_Click(object sender, EventArgs e)
        {
            await Presenter.AddToList();
        }

        private void btnEmptyList_Click(object sender, EventArgs e)
        {
            Presenter.EmptyList();
        }

        private async void btnResetFilters_Click(object sender, EventArgs e)
        {
            await Presenter.ResetFilters();
        }

        private void mnuMembers_Click(object sender, EventArgs e)
        {
            var frmMembers = _viewFactory.Create<FrmMembers>();
            CreateOrOpenForm(frmMembers);
        }
    }
}
