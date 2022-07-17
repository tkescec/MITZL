using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions.ExceptionLogging
{
    internal class MTFWSingleton
    {
        public static MultiThreadFileWriter? instance;

        public static MultiThreadFileWriter GetFileWriter()
        {
            if (instance == null)
            {
                instance = new MultiThreadFileWriter();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
}
