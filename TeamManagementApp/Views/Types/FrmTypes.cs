using TeamManagementApp.Models;
using TeamManagementApp.Util.CommonControls;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Views.Members
{
    public partial class FrmTypes : BaseView, ITypesView
    {
        #region Properties
        public ICommonComboBox<ProjectType, long> CmbTypes { get; set; }
        public ICommonTextBox TxtTypeDetails { get; set; }
        public ICommonCheckBox ChkActive { get; set; }
        #endregion
        public TypesPresenter Presenter { get; private set; }
        public FrmTypes(TypesPresenter presenter)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
        }

        private void InitializeWrappers()
        {
            CmbTypes = new WinWrapperComboBox<ProjectType, long>(cmbType, nameof(ProjectType.Type), nameof(ProjectType.TypeId));
            TxtTypeDetails = new WinWrapperTextBox(txtTypeDetails);
            ChkActive = new WinWrapperCheckBox(chkActive);
        }

        private async void FrmTypes_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.FillForSelectedType();
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
