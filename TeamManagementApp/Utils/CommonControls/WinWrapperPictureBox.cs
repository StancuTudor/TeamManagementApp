using TeamManagementApp.Utils.CommonControls.Interfaces;

namespace TeamManagementApp.Utils.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for PictureBox.
    /// </summary>
    public class WinWrapperPictureBox : ICommonPictureBox
    {
        protected readonly PictureBox _pictureBox;

        public bool Visible { get => _pictureBox.Visible; set => _pictureBox.Visible = value; }
        public int Height { get => _pictureBox.Height; set => _pictureBox.Height = value; }
        public int Width { get => _pictureBox.Width; set => _pictureBox.Width = value; }
        public Image Image { get => _pictureBox.Image; set => _pictureBox.Image = value; }

        public WinWrapperPictureBox(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
        }
    }
}
