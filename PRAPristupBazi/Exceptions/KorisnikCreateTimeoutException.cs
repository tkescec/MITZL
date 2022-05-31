using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions
{
    public class KorisnikCreateTimeoutException : Exception
    {
        public KorisnikCreateTimeoutException()
        {
        }

        public KorisnikCreateTimeoutException(string? message) : base(message)
        {
        }
    }
}
