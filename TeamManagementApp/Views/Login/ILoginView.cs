namespace TeamManagementApp.Views.Login
{
    public interface ILoginView
    {
        string User { get; set; }
        string Password { get; set; }
        string Error { get; set; }
        void Close();
    }
    public enum LoginState
    {
        Loading,
        NotAutorized,
        Autorized
    }
}
