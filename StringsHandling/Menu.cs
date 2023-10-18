using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using StringsHandling.InputProviders;
using StringsHandling.OutputProviders;


namespace StringsHandling
{
    internal class Menu
    {
        private readonly string _configPath;

        public Menu(string configPath) 
        {
            _configPath = configPath;
        }

        public void Start()
        {
            var formeds = new List<FormedTask>();

            try
            {
                Console.WriteLine($"Loading configure file {_configPath} ...");

                var tasks = JsonDocument.Parse(File.ReadAllText(_configPath)).RootElement.EnumerateArray();

                while (tasks.MoveNext())
                {
                    if (TryParse(tasks.Current, out var task))
                    {
                        formeds.Add(task);
                    }
                }

                foreach (var task in formeds) 
                {
                    Console.WriteLine(task.ToString());
                    Console.WriteLine();
                }

                foreach (var task in formeds)
                {
                    task.SolveTask();
                }

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static bool TryParse(JsonElement element, out FormedTask task)
        {
            try
            {
                var inputProvider = GetInputProvider(element);

                var outputProvider = GetOutputProvider(element);

                var command = GetCommand(element);

                task = new(inputProvider, command, outputProvider);

                return true;

            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($" {element}");
            }
        }

        private static IInputProvider GetInputProvider(JsonElement element)
        {
            var type = element.GetProperty("inputProvider").ToString();
            var fileName = element.GetProperty("inputFile").ToString();

            return type switch
            {
                "console" => new ConsoleInput(),
                "file" => new FileInput(fileName),
                _ => throw new InvalidOperationException()
            };
        }

        private static IOutputProvider GetOutputProvider(JsonElement element)
        {
            var type = element.GetProperty("outputProvider").ToString();
            var fileName = element.GetProperty("outputFile").ToString();

            return type switch
            {
                "console" => new ConsoleOutput(),
                "file" => new FileOutput(fileName),
                _ => throw new InvalidOperationException()
            };
        }

        private static string GetCommand(JsonElement element)
        {
            var command = element.GetProperty("command").ToString();

            if (string.IsNullOrWhiteSpace(command))
            {
                throw new InvalidOperationException();
            }

            return command;
        }

    }
}
