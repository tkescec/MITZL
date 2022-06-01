using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions
{
    public class KnjizaraCreateException : Exception
    {
        public KnjizaraCreateException()
        {
        }

        public KnjizaraCreateException(string? message) : base(message)
        {
        }
    }
}
