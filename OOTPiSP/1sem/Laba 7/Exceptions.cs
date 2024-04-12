using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    internal class Exceptions : Exception
    {
        public Exceptions(string message)
        : base(message)
        {
            Console.WriteLine(message);
        }

        public Exceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
