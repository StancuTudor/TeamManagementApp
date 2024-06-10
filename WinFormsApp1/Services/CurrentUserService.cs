using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Services
{
    public interface ICurrentUserService 
    { 
        int UserId { get; set; }
        string UserName { get; set; }
    }
    public class CurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
