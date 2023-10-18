using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.InputProviders
{
    internal class ConsoleInput : IInputProvider
    {
        public string Read()
        {
            Console.WriteLine("Enter text to analyze, special symbol --end to stop entering");

            var text = new StringBuilder();

            while (true)
            {
                var line = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (line.Equals("--end"))
                    {
                        return text.ToString();
                    }

                    text.AppendLine(line);
                }

            }
            
        }

        public override string ToString()
        {
            return "console";
        }
    }
}
