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
       /// <summary>
       /// Used only for datagrids with only one checkbox column
       /// Alternative for listview checkboxes
       /// </summary>
       /// <returns></returns>
        public async Task<IList<T>> GetCheckedRowsTags()
        {
            int i = 0;
            int index = -1;
            List<T> tags = new List<T>();
            foreach (var column in _dataGridView.Columns)
            {
                if (column is DataGridViewCheckBoxColumn)
                {
                    index = i;
                    break;
                }
                i++;
            }
            if (index == -1)
                return new List<T>();
            var rows = _dataGridView.Rows;
            foreach (DataGridViewRow row in rows)
            {
                if (row.IsNewRow)
                    continue;
                object value = row.Cells[index].Value;
                if (value != null && (bool)value)
                {
                    if (row.Tag != null && row.Tag is T)
                        tags.Add((T)row.Tag);
                }
            }
            return tags;

        }
        public int RowCount { get => _dataGridView.RowCount; set => _dataGridView.RowCount = value; }
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
