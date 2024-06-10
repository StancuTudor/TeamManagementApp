using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Models
{
    public enum ValidationStatusCode
    {
        Loading,
        Success,
        Failed
    }
    public class ValidateUserOut
    {
        public string Result { get; set; } =string.Empty;
        public ValidationStatusCode StatusCode { get; set; }
        public UserLogin? UserLogin { get; set; }
    }
}
