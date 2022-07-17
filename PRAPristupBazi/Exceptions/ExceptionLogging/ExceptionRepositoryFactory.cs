using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions.ExceptionLogging
{
    internal static class ExceptionRepositoryFactory
    {
        public static IExceptionRepository GetRepository()
        {
            return new ExceptionFileRepository();
        }
    }
}
