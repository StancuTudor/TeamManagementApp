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
using TeamManagementApp.Views.Main;

namespace TeamManagementApp.Views.Members
{
    public partial class FrmTypes : BaseView, ITypesView
    {
        #region Properties
        public ICommonComboBox<ProjectType, int> CmbTypes { get; set; }
        public ICommonTextBox TxtTypeDetails { get; set; }
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
            CmbTypes = new WinWrapperComboBox<ProjectType, int>(cmbType, nameof(ProjectType.Type), nameof(ProjectType.TypeId));
            TxtTypeDetails = new WinWrapperTextBox(txtTypeDetails);
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
