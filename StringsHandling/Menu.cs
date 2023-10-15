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

        private Text Text { get; set; }

        public Menu() 
        {
            Navigation = new FileNavigation();
            Text = new Text();
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
                    case "h" or "help":
                        FileNavigation.Help();
                        break;
                    case string s when s.Length >= 4 && s[0..4] == "open":
                        if (Navigation.OpenText(s[5..], out var text))
                        {
                            Text._text = text;
                            Console.WriteLine($"Текст успешно считан из файла {s[5..]}");
                        }
                        else 
                        {
                            Console.WriteLine("Не удалось считать текст из файла");
                        }
                        break;
                    case string s when s.Length == 9 && s[0..6] == "find w":
                        if (Text._text.Length != 0)
                        {
                            var words = Text.FindWords(s[7..]);

                            foreach (var word in words)
                            {
                                Console.WriteLine(word);
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Для начала считайте какой-нибудь текс");
                        }
                        break;
                    case string s when s.Length == 9 && s[0..6] == "find s":
                        if (Text._text.Length != 0)
                        {
                            var sentences = Text.FindSentences(s[7..]);

                            foreach (var sentence in sentences)
                            {
                                Console.WriteLine(sentence);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Для начала считайте какой-нибудь текс");
                        }
                        break;
                    case "replace":
                        Console.WriteLine("До замены:");
                        Text.PrintText();
                        Text.ReplaceNumbersWithText();
                        Console.WriteLine("После замены:");
                        Text.PrintText();
                        break;
                    case "print":
                        Text.PrintText();
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
