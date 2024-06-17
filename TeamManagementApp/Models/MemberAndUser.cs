using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class MemberAndUser : UserLogin
    {
        public string MemberName { get; set; } = string.Empty;
    }
}
