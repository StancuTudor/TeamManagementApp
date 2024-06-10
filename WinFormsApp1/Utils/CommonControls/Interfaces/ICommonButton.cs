namespace TeamManagementApp.Util.CommonControls.Interfaces
{
    public interface ICommonButton
    {
        string Text { get; set; }
        bool Enabled { get; set; }
        bool Visible { get; set; }
    }

    public interface ICommonButton<T> : ICommonButton
    {
        T Tag { get; set; }
    }
}
