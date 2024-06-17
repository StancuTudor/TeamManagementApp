using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for GroupBox.
    /// </summary>
    public class WinWrapperGroupBox : ICommonGroupBox
    {
        protected readonly GroupBox _groupBox;

        public string Text { get => _groupBox.Text; set => _groupBox.Text = value; }
        public bool Enabled { get => _groupBox.Enabled; set => _groupBox.Enabled = value; }
        public bool Visible { get => _groupBox.Visible; set => _groupBox.Visible = value; }

        public WinWrapperGroupBox(GroupBox groupBox)
        {
            _groupBox = groupBox;
        }
        public void BringToTheFront()
        {
            _groupBox.BringToFront();
        }
    }
}
