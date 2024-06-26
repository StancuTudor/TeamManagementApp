﻿using System.ComponentModel;

namespace TeamManagementApp.Utils.CommonControls.Interfaces
{
    public interface ICommonDataGridView<T>
    {
        BindingList<T> DataSource { get; set; }
        IList<T> SelectedRows { get; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        object this[int colIndex, int rowIndex] { get; set; }
        int RowCount { get; set; }
        void AddColumn(DataGridViewTextBoxColumn column);
    }

    public interface ICommonDataGridView<T, U> : ICommonDataGridView<T>
    {
        U Tag { get; set; }
    }
}
