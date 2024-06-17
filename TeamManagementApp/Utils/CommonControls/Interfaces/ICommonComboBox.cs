using System.ComponentModel;

namespace TeamManagementApp.Utils.CommonControls.Interfaces
{
    public interface ICommonComboBox<T, U>
    {
        int SelectedIndex { get; set; }
        T SelectedItem { get; set; }
        U SelectedValue { get; set; }
        string ValueMember { get; }
        string DisplayMember { get; }
        string Text { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        BindingList<T> DataSource { get; set; }
        int ItemsCount { get; }
        int SelectionStart { get; set; }
    }

    public interface ICommonComboBox<T, U, W> : ICommonComboBox<T, U>
    {
        W Tag { get; set; }
    }
}
