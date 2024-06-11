using TeamManagementApp.Util.CommonControls.Interfaces;

namespace TeamManagementApp.Util.CommonControls
{
    /// <summary>
    /// Creates a basic wrapper for DateTimePicker.
    /// </summary>
    public class WinWrapperDateTimePicker : ICommonDateTimePicker
    {
        protected readonly DateTimePicker _dateTimePicker;

        public DateTime Value { get => _dateTimePicker.Value; set => _dateTimePicker.Value = value; }
        public bool Enabled { get => _dateTimePicker.Enabled; set => _dateTimePicker.Enabled = value; }
        public bool Visible { get => _dateTimePicker.Visible; set => _dateTimePicker.Visible = value; }
        public bool Checked { get => _dateTimePicker.Checked; set => _dateTimePicker.Checked = value; }

        public WinWrapperDateTimePicker(DateTimePicker dateTimePicker)
        {
            _dateTimePicker = dateTimePicker;
        }

        public static implicit operator DateTime(WinWrapperDateTimePicker dtp) => dtp.Value;
    }

    /// <summary>
    /// Creates a wrapper for DateTimePicker which also contains the Tag property. 
    /// </summary>
    /// <typeparam name="T">The type of the Tag property.</typeparam>
    public class WinWrapperDateTimePicker<T> : WinWrapperDateTimePicker, ICommonDateTimePicker<T>
    {
        public T Tag { get => (T)_dateTimePicker.Tag; set => _dateTimePicker.Tag = value; }
        public WinWrapperDateTimePicker(DateTimePicker dateTimePicker) : base(dateTimePicker) { }
    }
}
