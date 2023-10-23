using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInvertory.Loggers
{
    internal class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string? path)
        {
            if (!File.Exists(path))
            {
                throw new InvalidOperationException();
            }

            _path = path;
        }

        public void Log(string message, LogLevel level)
        {
            File.AppendAllText(_path, $"[{DateTime.Now}] [{level.MyToString()}] {message}\n");
        }
    }
}
