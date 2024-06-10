using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for TextBox.
    /// </summary>
    public class WinWrapperTextBox : ICommonTextBox
    {
        protected readonly TextBox _textBox;

        public string Text { get => _textBox.Text; set => _textBox.Text = value; }
        public bool Visible { get => _textBox.Visible; set => _textBox.Visible = value; }
        public bool Enabled { get => _textBox.Enabled; set => _textBox.Enabled = value; }
        public bool ReadOnly { get => _textBox.ReadOnly; set => _textBox.ReadOnly = value; }
        public int SelectionStart { get => _textBox.SelectionStart; set => _textBox.SelectionStart = value; }
        public void Focus()
        {
            _textBox.Focus();
            _textBox.SelectionStart = _textBox.Text.Length;
        }

        public WinWrapperTextBox(TextBox textBox)
        {
            _textBox = textBox;
        }
    }

    /// <summary>
    /// Creates a wrapper for TextBox which also contains the Tag property.
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperTextBox<T> : WinWrapperTextBox, ICommonTextBox<T>
    {
        public T Tag { get => (T)_textBox.Tag; set => _textBox.Tag = value; }

        public WinWrapperTextBox(TextBox textBox) : base(textBox) { }
    }
}
