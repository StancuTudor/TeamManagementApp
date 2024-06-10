using TeamManagementApp.Util.CommonControls.Interfaces;
using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    public class WinWrapperRichTextBox : ICommonRichTextBox
    {
        protected readonly RichTextBox _richTextBox;

        public string Text { get => _richTextBox.Text; set => _richTextBox.Text = value; }
        public bool Visible { get => _richTextBox.Visible; set => _richTextBox.Visible = value; }
        public bool Enabled { get => _richTextBox.Enabled; set => _richTextBox.Enabled = value; }
        public bool ReadOnly { get => _richTextBox.ReadOnly; set => _richTextBox.ReadOnly = value; }
        public int SelectionStart { get => _richTextBox.SelectionStart; set => _richTextBox.SelectionStart = value; }
        public void Focus()
        {
            _richTextBox.Focus();
            _richTextBox.SelectionStart = _richTextBox.Text.Length;
        }

        public WinWrapperRichTextBox(RichTextBox textBox)
        {
            _richTextBox = textBox;
        }
    }

    /// <summary>
    /// Creates a wrapper for TextBox which also contains the Tag property.
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperRichTextBox<T> : WinWrapperRichTextBox, ICommonRichTextBox<T>
    {
        public T Tag { get => (T)_richTextBox.Tag; set => _richTextBox.Tag = value; }

        public WinWrapperRichTextBox(RichTextBox textBox) : base(textBox) { }
    }
}
