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
    public partial class FrmMembers : BaseView, IMembersView
    {
        #region Properties
        public ICommonComboBox<Member, int> CmbMembers { get; set; }
        public ICommonTextBox TxtMemberDetails { get; set; }
        public ICommonComboBox<MemberClass, int> CmbClass { get; set; }
        public ICommonComboBox<UserLogin, int> CmbUser { get; set; }
        public ICommonCheckBox ChkActive { get; set; }
        #endregion
        public MembersPresenter Presenter { get; private set; }
        public FrmMembers(MembersPresenter presenter)
        {
            InitializeComponent();
            InitializeWrappers();

            Presenter = presenter;
            Presenter.SetView(this);
        }

        private void InitializeWrappers()
        {
            CmbMembers = new WinWrapperComboBox<Member, int>(cmbMember, nameof(Member.Name), nameof(Member.MemberId));
            TxtMemberDetails = new WinWrapperTextBox(txtMemberDetails);
            CmbClass = new WinWrapperComboBox<MemberClass, int>(cmbClass, nameof(MemberClass.ClassName), nameof(MemberClass.ClassId));
            CmbUser = new WinWrapperComboBox<UserLogin, int>(cmbUser, nameof(UserLogin.UserName), nameof(UserLogin.UserId));
            ChkActive = new WinWrapperCheckBox(chkActive);
        }

        private async void FrmMembers_Load(object sender, EventArgs e)
        {
            await Presenter.FormLoad();
        }

        private void cmbMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.FillForSelectedMember();
        }

        private async void btnApplyFilters_Click(object sender, EventArgs e)
        {
            await Presenter.DeleteMember();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await Presenter.Save();
        }
    }
}
