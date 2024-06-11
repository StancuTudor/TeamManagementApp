namespace TeamManagementApp.Util.CommonControls.Interfaces
{
    public interface ICommonGroupBox
    {
        string Text { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        void BringToTheFront();
    }
}
