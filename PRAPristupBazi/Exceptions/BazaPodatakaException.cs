using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions
{
    public class BazaPodatakaException : Exception
    {
        public BazaPodatakaException()
        {
        }

        public BazaPodatakaException(string? message) : base(message)
        {
        }
    }
}
