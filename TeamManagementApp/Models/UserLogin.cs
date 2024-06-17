namespace TeamManagementApp.Models
{
    public class UserLogin
    {
        public long UserId { set; get; }
        public string Username { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
        public long? MemberId { set; get; }
    }
}
