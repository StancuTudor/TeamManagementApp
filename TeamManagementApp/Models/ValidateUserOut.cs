namespace TeamManagementApp.Models
{
    public enum ValidationStatusCode
    {
        Loading,
        Success,
        Failed
    }
    public class ValidateUserOut
    {
        public string Result { get; set; } = string.Empty;
        public ValidationStatusCode StatusCode { get; set; }
        public UserLogin? UserLogin { get; set; }
    }
}
