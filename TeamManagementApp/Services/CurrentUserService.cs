namespace TeamManagementApp.Services
{
    public interface ICurrentUserService
    {
        long UserId { get; set; }
        string Username { get; set; }
        long? MemberId { get; set; }
    }
    public class CurrentUserService : ICurrentUserService
    {
        public long UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public long? MemberId { get; set; }
    }
}
