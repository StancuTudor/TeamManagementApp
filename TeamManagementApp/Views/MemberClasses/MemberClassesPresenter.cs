﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamManagementApp.Models.Filters;
using TeamManagementApp.Models;
using TeamManagementApp.Services;
using TeamManagementApp.Views.Main;
using TeamManagementApp.Utils;

namespace TeamManagementApp.Views.Members
{
    public class MemberClassesPresenter
    {
        private IMemberClassesView _view;
        private readonly ICommonService _commonService;
        private readonly IMemberClassesService _memberClassesService;

        public MemberClassesPresenter(ICommonService commonService, IMemberClassesService memberClassesService)
        {
            _commonService = commonService;
            _memberClassesService = memberClassesService;
        }
        public void SetView(IMemberClassesView view)
        {
            _view = view;
        }

        public async Task FormLoad()
        {
            await InitializeControls();
        }
        private async Task InitializeControls()
        {
            await InitializeMemberClasses();
        }
        private async Task InitializeMemberClasses()
        {
            var memberClasses = new List<MemberClass>
            {
                new MemberClass()
                {
                    ClassName = $"({Selection.New.ToString()})",
                    ClassId = (long)Selection.New
                }
            };
            memberClasses.AddRange(await _commonService.GetAllMemberClasses(ActiveSelection.All));

            _view.CmbMemberClasses.DataSource = new BindingList<MemberClass>(memberClasses);
        }

        public void FillForSelectedMemberClass()
        {
            var selectedMemberClass = _view.CmbMemberClasses.SelectedItem;
            if(selectedMemberClass.ClassId == (long)Selection.New)
            {
                FillForNewMemberClass();
            }
            else
            {
                FillForMemberClass(selectedMemberClass);
            }
        }
        private void FillForNewMemberClass()
        {
            _view.TxtMemberClassDetails.Text = string.Empty;
            _view.ChkActive.Checked = true;
        }
        private void FillForMemberClass(MemberClass selectedMemberClass)
        {
            _view.TxtMemberClassDetails.Text = selectedMemberClass.ClassName;
            _view.ChkActive.Checked = selectedMemberClass.Active;
        }

        public async Task DeleteMember()
        {
            try
            {
                var memberClass = _view.CmbMemberClasses.SelectedItem;
                if (memberClass.ClassId == (long)Selection.New)
                    throw new InvalidOperationException("Invalid operation.");

                var result = MessageBox.Show($"Are you sure you want to delete {memberClass.ClassName}?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    await DeleteMemberClassById(memberClass.ClassId);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
        private async Task DeleteMemberClassById(long memberId)
        {
            await _memberClassesService.DeleteMemberClassById(memberId);
            MessageBox.Show("Member class delete succesfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await InitializeMemberClasses();
        }

        public async Task Save()
        {
            var memberClassId = _view.CmbMemberClasses.SelectedValue;
            var newMemberClass = GetMemberClassModelFromControls();
            if (memberClassId == (long)Selection.New)
                await _memberClassesService.InsertNewMemberClass(newMemberClass);
            else
                await _memberClassesService.UpdateMemberClass(newMemberClass);

            MessageBox.Show("Member class saved succesfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await InitializeMemberClasses();
        }

        private MemberClass GetMemberClassModelFromControls()
        {
            return new MemberClass()
            {
                ClassId = _view.CmbMemberClasses.SelectedValue == (long)Selection.New ? 0 : _view.CmbMemberClasses.SelectedValue,
                ClassName = _view.TxtMemberClassDetails.Text.Trim(),
                Active = _view.ChkActive.Checked
            };
        }
    }
}
