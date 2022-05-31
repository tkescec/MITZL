
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions.ExceptionLogging
{
    internal class ExceptionFileRepository : IExceptionRepository
    {
        public void LogException(Exception e)
        {
            string computerName = System.Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToShortDateString();
            string time = dateTime.ToLongTimeString();
            string timeMs = DateTime.Now.Millisecond.ToString();
            string exceptionType = e.GetType().Name;
            string exceptionMessage = e.Message;

            string log = $"EXCEPTION-LOG | {computerName} | {date} {time}:{timeMs} | {exceptionType} | {exceptionMessage}";

            MTFWSingleton.GetFileWriter().WriteLine(log);
        }
    }
}
