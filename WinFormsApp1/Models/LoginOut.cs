using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public class LoginOut
    {
        public ValidateUserOut UserData { get; set; }
        public LoginOut()
        {
            UserData = new ValidateUserOut();
        }
    }
}
