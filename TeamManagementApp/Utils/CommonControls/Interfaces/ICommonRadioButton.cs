namespace TeamManagementApp.Util.CommonControls.Interfaces
{
    public interface ICommonRadioButton
    {
        bool Checked { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
        string Text { get; set; }
    }

    public interface ICommonRadioButton<T> : ICommonRadioButton
    {
        T Tag { get; set; }
    }
}
