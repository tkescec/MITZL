using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions.ExceptionLogging
{
    internal static class ExceptionLogger
    {
        public static void LogExceptionToDest(this Exception e)
        {
            ExceptionRepositoryFactory.GetRepository().LogException(e);
        }
    }
}
