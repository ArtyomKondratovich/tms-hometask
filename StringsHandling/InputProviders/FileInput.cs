using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling.InputProviders
{
    internal class FileInput : IInputProvider
    {
        private readonly string? _fileName;

        public FileInput(string? fileName)
        {
            _fileName = fileName;
        }

        public string Read()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_fileName))
                {
                    throw new InvalidOperationException();
                }

                return File.ReadAllText(_fileName);
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
