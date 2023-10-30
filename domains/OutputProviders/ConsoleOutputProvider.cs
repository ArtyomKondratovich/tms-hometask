using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domains.OutputProviders
{
    internal class ConsoleOutputProvider : IOutputProvider
    {
        public void Write(string content, string fileName)
        {
            Console.WriteLine(content + fileName);
        }
    }
}
