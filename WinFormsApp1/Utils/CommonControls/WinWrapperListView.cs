using TeamManagementApp.Util.CommonControls.Interfaces;
using static System.Windows.Forms.ListViewItem;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a base wrapper for ListView with few properties.
    /// </summary>
    public abstract class WinWrapperListViewBase
    {
        protected readonly ListView _listView;

        public bool Enabled { get => _listView.Enabled; set => _listView.Enabled = value; }
        public bool Visible { get => _listView.Visible; set => _listView.Visible = value; }
        public bool CheckBoxes { get => _listView.CheckBoxes; set => _listView.CheckBoxes = value; }

        public WinWrapperListViewBase(ListView listView)
        {
            _listView = listView;
        }

        public void Remove(int index)
        {
            _listView.Items.RemoveAt(index);
        }

        public void Clear()
        {
            _listView.Items.Clear();
        }

        public ListView GetListViewObject()
        {
            return _listView;
        }
    }

    /// <summary>
    /// Creates a basic wrapper for ListView.
    /// </summary>
    public class WinWrapperListView : WinWrapperListViewBase, ICommonListView
    {
        public List<ICommonListViewItem> Items { get => _listView.Items.Cast<ListViewItem>().Select(el => (ICommonListViewItem)new WinWrapperListViewItem(el)).ToList(); }
        public List<ICommonListViewItem> SelectedItems { get => _listView.SelectedItems.Cast<ListViewItem>().Select(el => (ICommonListViewItem)new WinWrapperListViewItem(el)).ToList(); }
        public List<ICommonListViewItem> CheckedItems
        {
            get
            {
                var result = new List<ICommonListViewItem>();
                foreach (WinWrapperListViewItem item in Items)
                {
                    if (item.Checked) result.Add(item);
                }
                return result;
            }
        }

        public WinWrapperListView(ListView listView) : base(listView) { }

        public string this[int colIndex, int rowIndex]
        {
            get => Items[rowIndex].RowData[colIndex];
            set
            {
                if (colIndex == 0) _listView.Items[rowIndex].Text = value;
                else _listView.Items[rowIndex].SubItems[colIndex - 1].Text = value;
            }
        }
        public void Add(string text)
        {
            _listView.Items.Add(text);
        }
        public void Add(string[] items)
        {
            _listView.Items.Add(new ListViewItem(items));
        }
        public void Add(ICommonListViewItem listViewItem)
        {
            _listView.Items.Add(new ListViewItem(listViewItem.RowData));
        }
        public void BeginUpdate()
        {
            _listView.BeginUpdate();
        }
        public void EndUpdate()
        {
            _listView.EndUpdate();
        }
    }

    /// <summary>
    /// Creates a basic wrapper for Panel which also contains the Tag property for each item.
    /// </summary>
    /// <typeparam name="T">The type of the ListViewItems Tag property.</typeparam>
    public class WinWrapperListView<T> : WinWrapperListViewBase, ICommonListView<T>
    {
        public List<ICommonListViewItem<T>> Items { get => _listView.Items.Cast<ListViewItem>().Select(el => (ICommonListViewItem<T>)new WinWrapperListViewItem<T>(el)).ToList(); }
        public List<ICommonListViewItem<T>> SelectedItems { get => _listView.SelectedItems.Cast<ListViewItem>().Select(el => (ICommonListViewItem<T>)new WinWrapperListViewItem<T>(el)).ToList(); }
        public List<ICommonListViewItem<T>> CheckedItems
        {
            get
            {
                var result = new List<ICommonListViewItem<T>>();
                foreach (WinWrapperListViewItem<T> item in Items)
                {
                    if (item.Checked) result.Add(item);
                }
                return result;
            }
        }

        public WinWrapperListView(ListView listView) : base(listView) { }

        public string this[int colIndex, int rowIndex]
        {
            get => Items[rowIndex].RowData[colIndex];
            set
            {
                if (colIndex == 0) _listView.Items[rowIndex].Text = value;
                else _listView.Items[rowIndex].SubItems[colIndex].Text = value;
            }
        }
        public void Add(string text, T tag)
        {
            var item = _listView.Items.Add(text);
            item.Tag = tag;
        }
        public void Add(string[] items, T tag)
        {
            var item = _listView.Items.Add(new ListViewItem(items));
            item.Tag = tag;
        }
        public void Add(ICommonListViewItem<T> listViewItem)
        {
            var item = _listView.Items.Add(new ListViewItem(listViewItem.RowData));
            item.Tag = listViewItem.Tag;
        }
        public void BeginUpdate()
        {
            _listView.BeginUpdate();
        }
        public void EndUpdate()
        {
            _listView.EndUpdate();
        }
    }

    /// <summary>
    /// Creates a basic wrapper for ListViewItem. Used for WinWrapperListView.
    /// </summary>
    public class WinWrapperListViewItem : ICommonListViewItem
    {
        protected readonly ListViewItem _listViewItem;

        public string[] RowData
        {
            get
            {
                //var result = new List<string>() { _listViewItem.Text };
                var result = new List<string>() { };
                foreach (ListViewSubItem i in _listViewItem.SubItems)
                {
                    result.Add(i.Text);
                }
                return result.ToArray();
            }
        }
        public bool Checked { get => _listViewItem.Checked; set => _listViewItem.Checked = value; }
        public Color ForeColor { get => _listViewItem.ForeColor; set => _listViewItem.ForeColor = value; }
        public int Index { get => _listViewItem.Index; }

        public WinWrapperListViewItem(ListViewItem listViewItem)
        {
            _listViewItem = listViewItem;
        }
    }
    /// <summary>
    /// Creates a basic wrapper for ListViewItem which also contains the Tag property. Used for WinWrapperListView.
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperListViewItem<T> : WinWrapperListViewItem, ICommonListViewItem<T>
    {
        public T Tag { get => (T)_listViewItem.Tag; set => _listViewItem.Tag = value; }

        public WinWrapperListViewItem(ListViewItem listViewItem) : base(listViewItem) { }
    }
}
