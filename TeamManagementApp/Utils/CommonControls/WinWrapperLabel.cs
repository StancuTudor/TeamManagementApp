using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for Label.
    /// </summary>
    public class WinWrapperLabel : ICommonLabel
    {
        protected readonly Label _label;

        public string Text { get => _label.Text; set => _label.Text = value; }
        public bool Enabled { get => _label.Enabled; set => _label.Enabled = value; }
        public bool Visible { get => _label.Visible; set => _label.Visible = value; }

        public WinWrapperLabel(Label label)
        {
            _label = label;
        }
    }
}
