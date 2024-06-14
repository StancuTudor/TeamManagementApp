namespace TeamManagementApp.Services
{
    public interface ICurrentUserService
    {
        long UserId { get; set; }
        string UserName { get; set; }
        long? MemberId { get; set; }
    }
    public class CurrentUserService : ICurrentUserService
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public long? MemberId { get; set; }
    }
}
