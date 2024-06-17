using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for Form.
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperForm<T> : ICommonForm<T>
    {
        protected readonly Form _form;

        public string Text { get => _form.Text; set => _form.Text = value; }
        public bool Enabled { get => _form.Enabled; set => _form.Enabled = value; }
        public T Tag { get => (T)_form.Tag; set => _form.Tag = value; }
        public Size Size { get => _form.Size; set => _form.Size = value; }

        public WinWrapperForm(Form form)
        {
            _form = form;
        }
    }
}
