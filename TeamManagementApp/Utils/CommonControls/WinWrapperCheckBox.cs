using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for CheckBox.
    /// </summary>
    public class WinWrapperCheckBox : ICommonCheckBox
    {
        protected readonly CheckBox _checkBox;

        public string Text { get => _checkBox.Text; set => _checkBox.Text = value; }
        public bool Enabled { get => _checkBox.Enabled; set => _checkBox.Enabled = value; }
        public bool Visible { get => _checkBox.Visible; set => _checkBox.Visible = value; }
        public bool Checked { get => _checkBox.Checked; set => _checkBox.Checked = value; }

        public WinWrapperCheckBox(CheckBox checkBox)
        {
            _checkBox = checkBox;
        }

        public static implicit operator bool(WinWrapperCheckBox chk) => chk.Checked;
    }

    /// <summary>
    /// Creates a wrapper for CheckBox which also contains the Tag property. 
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperCheckBox<T> : WinWrapperCheckBox, ICommonCheckBox<T>
    {
        public T Tag { get => (T)_checkBox.Tag; set => _checkBox.Tag = value; }
        public WinWrapperCheckBox(CheckBox checkBox) : base(checkBox) { }
    }
}
