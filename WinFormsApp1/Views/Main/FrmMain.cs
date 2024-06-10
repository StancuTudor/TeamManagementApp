using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Views;
using TeamManagementApp.Views.Main;

namespace TeamManagementApp
{
    public partial class FrmMain : BaseView, IMainView
    {
        #region Properties
        public ICommonTextBox Text1 { get; set; }
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
            // Text1 = new WinWrapperTextBox(textBox1);
        }

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

        private async void button1_Click(object sender, EventArgs e)
        {
            await Presenter.Test();
        }
    }
}
