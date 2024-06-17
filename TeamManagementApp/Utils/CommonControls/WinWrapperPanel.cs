using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for Panel.
    /// </summary>
    public class WinWrapperPanel : ICommonPanel
    {
        protected readonly Panel _panel;

        public bool Enabled { get => _panel.Enabled; set => _panel.Enabled = value; }
        public bool Visible { get => _panel.Visible; set => _panel.Visible = value; }

        public WinWrapperPanel(Panel panel)
        {
            _panel = panel;
        }
    }
}
