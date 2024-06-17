namespace TeamManagementApp.Utils.CommonControls.Interfaces
{
    public interface ICommonCheckBox
    {
        bool Checked { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        string Text { get; set; }
    }

    public interface ICommonCheckBox<T> : ICommonCheckBox
    {
        T Tag { get; set; }
    }
}
