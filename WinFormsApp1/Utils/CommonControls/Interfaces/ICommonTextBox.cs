namespace TeamManagementApp.Util.CommonControls.Interfaces
{
    public interface ICommonTextBox
    {
        string Text { get; set; }
        bool Visible { get; set; }
        bool Enabled { get; set; }
        bool ReadOnly { get; set; }
        int SelectionStart { get; set; }
        void Focus();
    }

    public interface ICommonTextBox<T> : ICommonTextBox
    {
        T Tag { get; set; }
    }
}
