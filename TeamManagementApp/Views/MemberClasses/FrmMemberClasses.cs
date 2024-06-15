using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.MembersClasses
{
    public partial class FrmMemberClasses : BaseView, IMemberClassesView
    {
        #region Properties
        public ICommonComboBox<MemberClass, long> CmbMemberClasses { get; set; }
        public ICommonTextBox TxtMemberClassDetails { get; set; }
        public ICommonCheckBox ChkActive { get; set; }
        #endregion
        public MemberClassesPresenter Presenter { get; private set; }
        public FrmMemberClasses(MemberClassesPresenter presenter)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
        }

        private void InitializeWrappers()
        {
            CmbMemberClasses = new WinWrapperComboBox<MemberClass, long>(cmbMemberClass, nameof(MemberClass.ClassName), nameof(MemberClass.ClassId));
            TxtMemberClassDetails = new WinWrapperTextBox(txtMemberClassDetails);
            ChkActive = new WinWrapperCheckBox(chkActive);
        }

        private async void FrmMemberClasses_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        private void cmbMemberClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.FillForSelectedMemberClass();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await Presenter.DeleteMember();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await Presenter.Save();
        }
    }
}
