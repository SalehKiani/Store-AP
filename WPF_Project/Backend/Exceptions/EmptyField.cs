using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Project.Backend.Exceptions
{
    class EmptyField : Exception
    {
        public EmptyField()
        {
        }

        public EmptyField(string message)
            : base(message)
        {
        }

        public EmptyField(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
