using System.ComponentModel;
using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for ComboBox.
    /// </summary>
    /// <typeparam name="T">The type of the model equivalent to the type of a single entry in the DataSource.</typeparam>
    /// <typeparam name="U">The type of the property in the model associated with the ValueMember.</typeparam>
    public class WinWrapperComboBox<T, U> : ICommonComboBox<T, U>
    {
        private readonly string _displayMember;
        private readonly string _valueMember;
        protected readonly ComboBox _comboBox;

        public int SelectedIndex { get => _comboBox.SelectedIndex; set => _comboBox.SelectedIndex = value; }
        public T SelectedItem { get => (T)_comboBox.SelectedItem; set => _comboBox.SelectedItem = value; }
        public U SelectedValue { get => (U)_comboBox.SelectedValue; set => _comboBox.SelectedValue = value; }
        public string ValueMember => _comboBox.ValueMember;
        public string DisplayMember => _comboBox.DisplayMember;
        public string Text { get => _comboBox.Text; set => _comboBox.Text = value; }
        public bool Enabled { get => _comboBox.Enabled; set => _comboBox.Enabled = value; }
        public bool Visible { get => _comboBox.Visible; set => _comboBox.Visible = value; }
        public BindingList<T> DataSource
        {
            get => (BindingList<T>)_comboBox.DataSource;
            set
            {
                _comboBox.DataSource = value;
                _comboBox.DisplayMember = _displayMember;
            }
        }
        public int SelectionStart { get => _comboBox.SelectionStart; set => _comboBox.SelectionStart = value; }

        public WinWrapperComboBox(ComboBox comboBox, string displayMember, string valueMember)
        {
            _comboBox = comboBox;
            _comboBox.DisplayMember = displayMember;
            _comboBox.ValueMember = valueMember;
            _displayMember = displayMember;
            _valueMember = valueMember;
        }
        public int ItemsCount { get => _comboBox.Items.Count; }
    }

    /// <summary>
    /// Creates a wrapper for ComboBox which also contains the Tag property. 
    /// </summary>
    /// <typeparam name="T">The type of the model equivalent to the type of a single entry in the DataSource.</typeparam>
    /// <typeparam name="U">The type of the property in the model associated with the ValueMember.</typeparam>
    /// <typeparam name="W">The type of the Tag property.</typeparam>
    public class WinWrapperComboBox<T, U, W> : WinWrapperComboBox<T, U>, ICommonComboBox<T, U, W>
    {
        public W Tag { get => (W)_comboBox.Tag; set => _comboBox.Tag = value; }
        public WinWrapperComboBox(ComboBox comboBox, string displayMember, string valueMember) : base(comboBox, displayMember, valueMember) { }
    }
}
