using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class ProjectType
    {
        public long TypeId { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
