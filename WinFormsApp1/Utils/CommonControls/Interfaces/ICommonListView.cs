namespace TeamManagementApp.Util.CommonControls.Interfaces
{
    public interface ICommonListViewBase
    {
        bool Enabled { get; set; }
        bool Visible { get; set; }
        bool CheckBoxes { get; set; }

        void Remove(int index);
        void Clear();
        ListView GetListViewObject();
        void BeginUpdate();
        void EndUpdate();
    }

    public interface ICommonListView : ICommonListViewBase
    {
        List<ICommonListViewItem> Items { get; }
        List<ICommonListViewItem> SelectedItems { get; }
        List<ICommonListViewItem> CheckedItems { get; }
        string this[int colIndex, int rowIndex] { get; set; }

        void Add(string text);
        void Add(string[] items);
        void Add(ICommonListViewItem listViewItem);
    }

    public interface ICommonListView<T> : ICommonListViewBase
    {
        List<ICommonListViewItem<T>> Items { get; }
        List<ICommonListViewItem<T>> SelectedItems { get; }
        List<ICommonListViewItem<T>> CheckedItems { get; }
        string this[int colIndex, int rowIndex] { get; set; }

        void Add(string text, T tag);
        void Add(string[] items, T tag);
        void Add(ICommonListViewItem<T> listViewItem);
    }

    public interface ICommonListViewItem
    {
        string[] RowData { get; }
        bool Checked { get; set; }
        Color ForeColor { get; set; }
        int Index { get; }
    }

    public interface ICommonListViewItem<T> : ICommonListViewItem
    {
        T Tag { get; set; }
    }
}
