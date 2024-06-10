using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Views.Login
{
    public interface ILoginView
    {
        string User { get; set; }
        string Password { get; set; }
        string Error { get; set; }
        void Close();
    }
    public enum LoginState
    {
        NotAutorized,
        Autorized
    }
}
