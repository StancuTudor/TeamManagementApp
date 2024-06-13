using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class Member
    {
        public long MemberId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }
        public long ClassId { get; set; }
        public long? UserId { get; set; }
    }
}
