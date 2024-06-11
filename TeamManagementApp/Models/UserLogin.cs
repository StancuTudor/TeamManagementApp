using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class UserLogin
    {
        public int UserId { set; get; }
        public string UserName { set; get; } = string.Empty;
        public string Password { set; get; } = string.Empty;
        public int? MemberId { set; get; }
    }
}
