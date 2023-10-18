using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.OutputProviders
{
    internal class FileOutput : IOutputProvider
    {
        private readonly string? _fileName;

        public FileOutput(string? fileName)
        {
            _fileName = fileName;
        }

        public void Write(string output)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_fileName))
                {
                    throw new InvalidOperationException();
                }

                File.WriteAllText(_fileName, output);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            return $"file {_fileName}";
        }
    }
}
