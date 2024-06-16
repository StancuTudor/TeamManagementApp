using System.ComponentModel;
using TeamManagementApp.Models;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Services;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Views.Types
{
    public class TypesPresenter
    {
        private ITypesView _view;
        private readonly ICommonService _commonService;
        private readonly ITypesService _typesService;

        public TypesPresenter(ICommonService commonService, ITypesService typesService)
        {
            _commonService = commonService;
            _typesService = typesService;
        }
        public void SetView(ITypesView view)
        {
            _view = view;
        }

        public async Task FormLoad()
        {
            await InitializeControls();
        }
        private async Task InitializeControls()
        {
            await InitializeTypes();
        }
        private async Task InitializeTypes()
        {
            var types = new List<ProjectType>
            {
                new ProjectType()
                {
                    Type = $"({Selection.New.ToString()})",
                    TypeId = (long)Selection.New
                }
            };
            types.AddRange(await _commonService.GetAllProjectTypes(ActiveSelection.All));

            _view.CmbTypes.DataSource = new BindingList<ProjectType>(types);
        }

        public void FillForSelectedType()
        {
            var selectedType = _view.CmbTypes.SelectedItem;
            if (selectedType.TypeId == (long)Selection.New)
            {
                FillForNewType();
            }
            else
            {
                FillForType(selectedType);
            }
        }
        private void FillForNewType()
        {
            _view.TxtTypeDetails.Text = string.Empty;
            _view.ChkActive.Checked = true;
        }
        private void FillForType(ProjectType selectedType)
        {
            _view.TxtTypeDetails.Text = selectedType.Type;
            _view.ChkActive.Checked = selectedType.Active;
        }

        public async Task DeleteMember()
        {
            try
            {
                var type = _view.CmbTypes.SelectedItem;
                if (type.TypeId == (long)Selection.New)
                    throw new InvalidOperationException("Invalid operation.");

                var result = CustomMessageBox.ShowQuestion($"Are you sure you want to delete {type.Type}?");
                if (result == DialogResult.Yes)
                    await DeleteTypeById(type.TypeId);
            }
            catch (InvalidOperationException ex)
            {
                CustomMessageBox.ShowWarning(ex.Message);
            }
        }
        private async Task DeleteTypeById(long memberId)
        {
            await _typesService.DeleteTypeById(memberId);
            CustomMessageBox.ShowInfo("Type delete succesfully.");
            await InitializeTypes();
        }

        public async Task Save()
        {
            var typeId = _view.CmbTypes.SelectedValue;
            var newType = GetTypeModelFromControls();
            if (typeId == (long)Selection.New)
                await _typesService.InsertNewType(newType);
            else
                await _typesService.UpdateType(newType);

            CustomMessageBox.ShowInfo("Type saved succesfully.");
            await InitializeTypes();
        }

        private ProjectType GetTypeModelFromControls()
        {
            return new ProjectType()
            {
                TypeId = _view.CmbTypes.SelectedValue == (long)Selection.New ? 0 : _view.CmbTypes.SelectedValue,
                Type = _view.TxtTypeDetails.Text.Trim(),
                Active = _view.ChkActive.Checked
            };
        }
    }
}
