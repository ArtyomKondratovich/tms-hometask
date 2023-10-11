using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandling
{
    internal class Menu
    {
        private Dictionary<string, Matrix> _matrices { get; set; }

        public Menu()
        {
            _matrices = new Dictionary<string, Matrix>();
        }

        public void Start()
        {
            PrintMenu();
            while (true)
            {
                var command = GetString("Введите команду: ");

                switch (command) 
                {
                    case "add":
                        AddMatrix();
                        PrintMenu();
                        break;
                    case "find":
                    case "sortIncrease":
                    case "sortDecrease":
                    case "inversion":
                        var matrix = GetMatrix();

                        if (matrix == null)
                        {
                            break;
                        }

                        matrix.Operation(command);
                        break;
                    case "clear":
                        Console.Clear();
                        PrintMenu();
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine($"Неизвестная команда {command}");
                        break;
                }
            }
        }

        public void AddMatrix()
        {
            while (true)
            {
                var name = GetString("Введите название матрицы:");

                if (!_matrices.ContainsKey(name))
                {
                    var matrix = new Matrix();
                    matrix.EnterMatrix();
                    _matrices.Add(name, matrix);
                    Console.Clear();
                    Console.WriteLine($"В словарь успешно добавлена новая матрица с названием: {name}");
                    break;
                }
                else
                {
                    Console.WriteLine("Такое название матрицы уже существует");
                }
            }
        }

        public void PrintExistingMatrices()
        {
            Console.WriteLine("Все существующее матрицы:");
            foreach (var (name,_) in  _matrices)
            {
                Console.WriteLine(name);
            }
        }

        public Matrix? GetMatrix()
        {
            if (_matrices.Count == 0)
            {
                Console.WriteLine("Словарь матриц пуст");
                return null;
            }
            
            while (true)
            {
                PrintExistingMatrices();
                var name = GetString("Введите имя матрицы с которой хотите работать:");

                if (_matrices.ContainsKey(name))
                {
                    return _matrices[name];
                }
                else
                {
                    Console.WriteLine("Матрицы с таким именем не существует");
                }
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("Добавить новую матрицу -> add" +
                "\nНайти количество положительных/отрицательных чисел в матрице -> find" +
                "\nСортировка элементов матрицы построчно (в двух направлениях) -> sortIncerease/sortDecrease" +
                "\nИнверсия элементов матрицы построчно - inversion" +
                "\nОчистить консоль - clear" +
                "\nВыйти -> exit");
        }

        public static string GetString(string message)
        {
            while(true) 
            {
                Console.WriteLine(message);

                var command = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    Console.WriteLine("Вы ввели пустую строку или только пробелы");
                    continue;
                }

                command = command.Trim(' ');
  
                return command;
            }
        }

    }
}
