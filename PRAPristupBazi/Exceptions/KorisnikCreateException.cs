using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions
{
    public class KorisnikCreateException : Exception
    {
        public KorisnikCreateException()
        {
        }

        public KorisnikCreateException(string? message) : base(message)
        {
        }
    }
}
