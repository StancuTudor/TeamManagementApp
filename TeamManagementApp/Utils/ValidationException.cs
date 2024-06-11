using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TeamManagementApp.Utils
{
    class ValidationException : Exception
    {
        public string Title { get; set; } = string.Empty;
        public ValidationException()
        {
        }
        public ValidationException(string message) : base(message)
        {
        }
        public ValidationException(string message, string title) : base(message)
        {
            Title = title;
        }
    }
}
