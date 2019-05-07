using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend.Exceptions
{
    public class DBFail : Exception
    {
        public DBFail()
        {
        }

        public DBFail(string message)
            : base(message)
        {
        }

        public DBFail(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
