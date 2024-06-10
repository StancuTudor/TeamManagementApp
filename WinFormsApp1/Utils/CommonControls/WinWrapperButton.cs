using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for Button.
    /// </summary>
    public class WinWrapperButton : ICommonButton
    {
        protected readonly Button _button;
        public string Text { get => _button.Text; set => _button.Text = value; }
        public bool Enabled { get => _button.Enabled; set => _button.Enabled = value; }
        public bool Visible { get => _button.Visible; set => _button.Visible = value; }

        public WinWrapperButton(Button button)
        {
            _button = button;
        }
    }

    /// <summary>
    /// Creates a wrapper for Button which also contains the Tag property. 
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperButton<T> : WinWrapperButton, ICommonButton<T>
    {
        public T Tag { get => (T)_button.Tag; set => _button.Tag = value; }
        public WinWrapperButton(Button button) : base(button) { }
    }
}
