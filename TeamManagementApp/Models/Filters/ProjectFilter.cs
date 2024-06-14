namespace TeamManagementApp.Models.Filters
{
    public enum Selection
    {
        New = -3,
        Null = -2,
        Any = -1,
        Specific = 0
    }
    public class ProjectFilter
    {
        public Selection ProjectSelection { get; set; } = Selection.Any;
        public string Project { get; set; } = string.Empty;
        public Selection AssigneeSelection { get; set; } = Selection.Any;
        public List<long> Assignees { get; set; } = [];
        public Selection StatusSelection { get; set; } = Selection.Any;
        public List<long> Statuses { get; set; } = [];
        public Selection TypeSelection { get; set; } = Selection.Any;
        public List<long> Types { get; set; } = [];
    }
}
