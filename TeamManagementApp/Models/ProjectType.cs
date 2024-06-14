namespace TeamManagementApp.Models
{
    public class ProjectType
    {
        public long TypeId { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
