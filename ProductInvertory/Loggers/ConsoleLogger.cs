
using ProductInvertory;

namespace ProductInvertory.Loggers
{
    internal class ConsoleLogger : ILogger
    {

        public void Log(string message, LogLevel level)
        {
            Console.WriteLine($"[{DateTime.Now}] [{level.MyToString()}] {message}");
        }
    }
}
