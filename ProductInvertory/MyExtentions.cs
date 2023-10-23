using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductInvertory
{
    static class MyExtentions
    {
        private static readonly string[] separators = new string[] { " ", ",", "[", "]" };

        public static string MyToString(this LogLevel level) => level switch
        {
            LogLevel.mWarn => "WARN",
            LogLevel.mError => "ERROR",
            LogLevel.mTrace => "TRACE",
            LogLevel.mInfo => "INFO",
            LogLevel.mDebug => "DEBUG",
            LogLevel.mCritical => "CRITICAL",
            _ => "ERROR"
        };

        public static bool TryParse(this string? parametrsText, out Product? product)
        {
            if (string.IsNullOrWhiteSpace(parametrsText))
            {
                product = null;
                return false;
            }

            var parametrs = parametrsText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (parametrs.Length == 3)
            {
                try
                {
                    product = new Product { 
                        Name = parametrs[0],
                        Price = decimal.Parse(parametrs[1]),
                        Amount = int.Parse(parametrs[2])
                    };

                    return true;
                }
                catch 
                {
                    product = null;
                    return false;
                }
            }

            product = null;
            return false;
        }
    }
}
