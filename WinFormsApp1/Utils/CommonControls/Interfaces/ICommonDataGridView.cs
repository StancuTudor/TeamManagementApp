﻿using System.ComponentModel;

namespace Cargo.Util.CommonControls.Interfaces
{
    public interface ICommonDataGridView<T>
    {
        BindingList<T> DataSource { get; set; }
        IList<T> SelectedRows { get; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        object this[int colIndex, int rowIndex] { get; set; }
        Task<IList<T>> GetCheckedRowsTags();
        int RowCount { get; set; }
    }

    public interface ICommonDataGridView<T, U> : ICommonDataGridView<T>
    {
        U Tag { get; set; }
    }
}
