using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.OutputProviders
{
    internal class ConsoleOutput : IOutputProvider
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }

        public override string ToString()
        {
            return "console";
        }
    }
}
