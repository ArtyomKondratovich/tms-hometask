using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling
{

    internal class FileNavigation
    {
        private StringBuilder Path { get; set; }

        public FileNavigation()
        {
            Path = new StringBuilder("C:\\");
        }

        public void ChangeDirectory(string directory)
        {
            if (directory != ".." && Directory.Exists(Path.ToString() + directory))
            {
                Path.Append(directory);
                Path.Append('\\');
            }
            else if (directory != ".." && Directory.Exists(directory))
            {
                Path.Clear();
                Path.Append(directory);
                Path.Append('\\');
            }
            else if (directory == ".." && LastIndexOf('\\') != -1)
            {
                var startIndex = LastIndexOf('\\');
                var length = Path.Length - startIndex;
                Path.Remove(startIndex, length);
                Path.Append('\\');
            }
        }

        private int LastIndexOf(char symbol)
        {
            for (var i = Path.Length - 2; i >= 0; i--) 
            {
                if (Path[i] == symbol)
                    return i;
            }

            return -1;
        }

        public void DisplayDirectoryContents()
        {
            Console.WriteLine();

            var files = Directory.GetFiles(Path.ToString());
            var subfolders = Directory.GetDirectories(Path.ToString());
            var startIndex = Path.Length;
            foreach (var file in files)
            {
                Console.WriteLine($"<file> { file[startIndex..] }");
            }

            foreach (var subfolder in subfolders)
            {
                Console.WriteLine($"<DIR> { subfolder[startIndex..] }");
            }

            Console.WriteLine();
        }

        public void PrintCurrentFolderPath()
        {
            Console.Write(Path.ToString() + '>');
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void UnknowCommand()
        {
            Console.WriteLine("Unknown command, use help to know all existing commands");
        }

    }
}
