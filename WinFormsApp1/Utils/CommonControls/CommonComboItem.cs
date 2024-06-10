namespace TeamManagementApp.Util.CommonControls
{
    public class CommonComboItem
    {
        public string Display { get; set; }
    }

    public class CommonComboItem<T>
    {
        public string Display { get; set; }
        public T Value { get; set; }

        public CommonComboItem() { }
        public CommonComboItem(string display, T value)
        {
            Display = display;
            Value = value;
        }
    }
}
