using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for RadioButton.
    /// </summary>
    public class WinWrapperRadioButton : ICommonRadioButton
    {
        protected readonly RadioButton _radioButton;

        public string Text { get => _radioButton.Text; set => _radioButton.Text = value; }
        public bool Enabled { get => _radioButton.Enabled; set => _radioButton.Enabled = value; }
        public bool Visible { get => _radioButton.Visible; set => _radioButton.Visible = value; }
        public bool Checked { get => _radioButton.Checked; set => _radioButton.Checked = value; }

        public WinWrapperRadioButton(RadioButton radioButton)
        {
            _radioButton = radioButton;
        }

        public static implicit operator bool(WinWrapperRadioButton rb) => rb.Checked;
    }

    /// <summary>
    /// Creates a wrapper for RadioButton which also contains the Tag property. 
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperRadioButton<T> : WinWrapperRadioButton, ICommonRadioButton<T>
    {
        public T Tag { get => (T)_radioButton.Tag; set => _radioButton.Tag = value; }
        public WinWrapperRadioButton(RadioButton radioButton) : base(radioButton) { }
    }
}
