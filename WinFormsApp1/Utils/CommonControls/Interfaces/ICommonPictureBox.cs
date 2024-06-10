namespace TeamManagementApp.Util.CommonControls.Interfaces
{
    public interface ICommonPictureBox
    {
        bool Visible { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        Image Image { get; set; }
    }
}
