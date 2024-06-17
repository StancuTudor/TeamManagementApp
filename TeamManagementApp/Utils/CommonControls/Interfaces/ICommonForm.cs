namespace TeamManagementApp.Utils.CommonControls.Interfaces
{
    public interface ICommonForm<T>
    {
        T Tag { get; set; }
        bool Enabled { get; set; }
        string Text { get; set; }

        [Obsolete("This should not be used because on a browser the size cannot be perfectly emulated. Instead, check first if the control is WinWrapper and access the property from there: if(form is WinWrapperForm) form.Size")]
        Size Size { get; set; }
    }
}
