using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions.ExceptionLogging
{
    internal interface IExceptionRepository
    {
        public void LogException(Exception e);
    }
}
