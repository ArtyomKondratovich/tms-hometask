namespace domains.OutputProviders
{
    internal class FileOutputProvider : IOutputProvider
    {
        private readonly string? _directoryPath;

        public FileOutputProvider(string? path) 
        {
            _directoryPath = path;
        }

        public void Write(string content, string fileName)
        {
            try
            {
                File.WriteAllText(_directoryPath + fileName, content);
                Console.WriteLine(fileName + " saved succsessfully");
            }
            catch 
            {
                Console.WriteLine("Output error");
            }
        }
    }
}
