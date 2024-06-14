namespace TeamManagementApp.Models
{
    public class LoginOut
    {
        public ValidateUserOut UserData { get; set; }
        public LoginOut()
        {
            UserData = new ValidateUserOut();
        }
    }
}
