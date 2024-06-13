using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Models;
using TeamManagementApp.Services;
using TeamManagementApp.Views.Main;

namespace TeamManagementApp.Views.Members
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
            types.AddRange(await _commonService.GetAllProjectTypes());

            _view.CmbTypes.DataSource = new BindingList<ProjectType>(types);
        }

        public void FillForSelectedType()
        {
            var selectedType = _view.CmbTypes.SelectedItem;
            if(selectedType.TypeId == (long)Selection.New)
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
        }
        private void FillForType(ProjectType selectedType)
        {
            _view.TxtTypeDetails.Text = selectedType.Type;
        }

        public async Task DeleteMember()
        {
            try
            {
                var type = _view.CmbTypes.SelectedItem;
                if (type.TypeId == (long)Selection.New)
                    throw new InvalidOperationException("Invalid operation.");

                var result = MessageBox.Show($"Are you sure you want to delete {type.Type}?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    await DeleteTypeById(type.TypeId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
        private async Task DeleteTypeById(long memberId)
        {
            await _typesService.DeleteTypeById(memberId);
            await InitializeTypes();
            MessageBox.Show("Type delete succesfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public async Task Save()
        {
            var typeId = _view.CmbTypes.SelectedValue;
            var newType = GetMemberModelFromControls();
            if (typeId == (long)Selection.New)
                await _typesService.InsertNewType(newType);
            else
                await _typesService.UpdateType(newType);

            await InitializeTypes();
            MessageBox.Show("Type saved succesfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ProjectType GetMemberModelFromControls()
        {
            return new ProjectType()
            {
                TypeId = _view.CmbTypes.SelectedValue == (long)Selection.New ? 0 : _view.CmbTypes.SelectedValue,
                Type = _view.TxtTypeDetails.Text.Trim()
            };
        }
    }
}
