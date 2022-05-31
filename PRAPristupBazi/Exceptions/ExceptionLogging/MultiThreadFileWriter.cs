using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAPristupBazi.Exceptions.ExceptionLogging
{
    //BORROWED FROM: briancaos.wordpress.com

    internal class MultiThreadFileWriter
    {
        private static ConcurrentQueue<string> _textToWrite = new ConcurrentQueue<string>();
        private CancellationTokenSource _source = new CancellationTokenSource();
        private CancellationToken _token;
        private static string filePath = @"problemi.txt";

        public MultiThreadFileWriter()
        {
            _token = _source.Token;
            Task.Run(WriteToFile, _token);
        }

        public void WriteLine(string line)
        {
            _textToWrite.Enqueue(line);
        }

        private async void WriteToFile()
        {
            while (true)
            {
                if (_token.IsCancellationRequested)
                {
                    return;
                }
                using (StreamWriter w = File.AppendText(filePath))
                {
                    while (_textToWrite.TryDequeue(out string textLine))
                    {
                        await w.WriteLineAsync(textLine);
                    }
                    w.Flush();
                }
            }
        }
    }
}
