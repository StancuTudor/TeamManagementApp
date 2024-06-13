using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class MemberClass
    {
        public long ClassId {  get; set; }
        public string ClassName { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
