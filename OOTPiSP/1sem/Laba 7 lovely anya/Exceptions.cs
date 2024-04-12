using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal
{
    internal class Exceptions : Exception
    {
        public Exceptions(string message)
        : base(message)
        {
        }

        public Exceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}