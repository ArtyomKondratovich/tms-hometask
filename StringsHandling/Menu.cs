using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StringsHandling
{
    internal class Menu
    {
        private FileNavigation Navigation { get; set; }

        public Menu() 
        {
            Navigation = new FileNavigation();
        }

        public void Start()
        {
            while (true) 
            {
                Navigation.PrintCurrentFolderPath();
                var command = GetCommand();
                
                switch (command)
                {
                    case "cls":
                        FileNavigation.ClearConsole();
                        break;
                    case string s when s.Length >= 2 && s[0..2] == "cd":
                        Navigation.ChangeDirectory(s[3..]);
                        break;
                    case "dir":
                        Navigation.DisplayDirectoryContents();
                        break;
                    case "exit":
                        return;
                    default:
                        FileNavigation.UnknowCommand();
                        break;
                }
            }

        }

        private string GetCommand()
        {
            while (true) 
            {
                var command = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(command))
                    return command;

            }
        }
    }
}
