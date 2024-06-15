using TeamManagementApp.Utils;

namespace TeamManagementApp.Models.Filters
{
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
