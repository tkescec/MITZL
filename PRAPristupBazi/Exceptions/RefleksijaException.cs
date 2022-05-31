using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions
{
    public class RefleksijaException : Exception
    {
        public RefleksijaException()
        {
        }

        public RefleksijaException(string? message) : base(message)
        {
        }
    }
}
