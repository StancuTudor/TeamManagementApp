using TeamManagementApp.Util.CommonControls.Interfaces;
using System.ComponentModel;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for DataGridView.
    /// </summary>
    /// <typeparam name="T">The type of a single entry in the DataSource.</typeparam>
    public class WinWrapperDataGridView<T> : ICommonDataGridView<T>
    {
        protected DataGridView _dataGridView;

        public BindingList<T> DataSource { get => (BindingList<T>)_dataGridView.DataSource; set => _dataGridView.DataSource = value; }
        public IList<T> SelectedRows
        {
            get
            {
                var selectedRows = _dataGridView.SelectedRows.Cast<DataGridViewRow>();
                return selectedRows.Select(el => (T)el.DataBoundItem).ToList();
            }
        }
        public bool Enabled { get => _dataGridView.Enabled; set => _dataGridView.Enabled = value; }
        public bool Visible { get => _dataGridView.Visible; set => _dataGridView.Visible = value; }
        public object this[int colIndex, int rowIndex] { get => _dataGridView[colIndex, rowIndex].Value; set => _dataGridView[colIndex, rowIndex].Value = value; }
        public int RowCount { get => _dataGridView.RowCount; set => _dataGridView.RowCount = value; }
        public void AddColumn(DataGridViewTextBoxColumn column)
        {
            _dataGridView.Columns.Add(column);
        }

        public WinWrapperDataGridView(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }
    }

    /// <summary>
    /// Creates a wrapper for DataGridView which also contains the Tag property.
    /// </summary>
    /// <typeparam name="T">The type of a single entry in the DataSource.</typeparam>
    /// <typeparam name="U">The type of the Tag property.</typeparam>
    public class WinWrapperDataGridView<T, U> : WinWrapperDataGridView<T>, ICommonDataGridView<T, U>
    {
        public U Tag { get => (U)_dataGridView.Tag; set => _dataGridView.Tag = value; }

        public WinWrapperDataGridView(DataGridView dataGridView) : base(dataGridView) { }
    }
}
