using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    /// <summary>
    /// Default Project model.
    /// </summary>
    public class Project
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public long? Assignee { get; set; }
        public long StatusId { get; set; }
        public long TypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// Detailed Project model after joining tables.
    /// </summary>
    public class DetailedProject : Project
    {
        public string? AssigneeName { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }

    /// <summary>
    /// Project model for DataGridView display.
    /// </summary>
    public class DisplayedProject
    {
        [Browsable(false)]
        public long ProjectId { get; set; }
        public string Project { get; set; } = string.Empty;
        public string? Assignee { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DisplayedProject(DetailedProject detailedProject)
        {
            ProjectId = detailedProject.ProjectId;
            Project = detailedProject.ProjectName;
            Assignee = detailedProject.AssigneeName;
            Status = detailedProject.Status;
            Type = detailedProject.Type;
            StartDate = detailedProject.StartDate;
            EndDate = detailedProject.EndDate;
        }
    }
}
