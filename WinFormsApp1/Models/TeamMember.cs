using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class TeamMember
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Active { get; set; }
        public int Class { get; set; }
        public int? UserId { get; set; }
    }
}
