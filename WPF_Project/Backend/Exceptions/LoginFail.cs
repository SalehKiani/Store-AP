using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend.Exceptions
{
    public class LoginFail : Exception
    {
        public LoginFail()
        {
        }

        public LoginFail(string message)
            : base(message)
        {
        }

        public LoginFail(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
