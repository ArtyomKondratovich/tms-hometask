using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandling
{
    internal class Matrix
    {
        private int[,] _matrix { get; set; }

        public Matrix()
        {
            _matrix = new int[0, 0];
        }

        public Matrix(int n, int m)
        {
            _matrix = new int[n, m];
        }

        public void EnterMatrix()
        {
            var size = GetSize();
            _matrix = new int[size[0], size[1]];

            var i = 0;
            while (i < _matrix.GetLength(0))
            {
                Console.Write($"Введите строку матрицы #{i}: ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Вы ввели пустую строку или только пробелы, попробуйте снова");
                    continue;
                }

                try
                {
                    var row = line.Split(' ').Select(int.Parse).ToArray();

                    if (row.Length != _matrix.GetLength(1))
                    {
                        Console.WriteLine($"Вы ввели количество элементов != {_matrix.GetLength(1)} попробуйте снова");
                        continue;
                    }

                    for (var j = 0; j < _matrix.GetLength(1); j++)
                    {
                        _matrix[i, j] = row[j];
                    }
                    i++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка ввода, вы ввели неправильное число");
                }   
            }

            Console.Clear();
            Console.WriteLine("Вы успешно ввели матрицу");
        }

        public void PrintMatrix()
        {
            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", _matrix[i, j]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
        }

        public void Operation(string operation)
        {
            switch (operation)
            {
                case "find":
                    FindPositiveAndNegative();
                    break;
                case "sortIncrease":
                    Sort(0);
                    break;
                case "sortDecrease":
                    Sort(1);
                    break;
                case "inversion":
                    Inversion();
                    break;
            }
        }

        public void FindPositiveAndNegative()
        {
            PrintMatrix();
            var positiveCount = _matrix.Cast<int>().Count(x => x > 0);
            var negativeCount = _matrix.Cast<int>().Count(x => x < 0);
            Console.WriteLine($"число положительных {positiveCount}, число отрицательных {negativeCount}");
        }

        public void Sort(int direction)
        {
            Console.WriteLine("Перед сортировкой");
            PrintMatrix();

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                if (direction == 0)
                {
                    for (var j = 0; j < _matrix.GetLength(1); j++)
                    {
                        for (var k = j + 1;  k < _matrix.GetLength(1); k++)
                        {
                            if (_matrix[i, k] < _matrix[i, j])
                            {
                                (_matrix[i, k], _matrix[i, j]) = (_matrix[i, j], _matrix[i, k]);
                            }
                        }
                    }
                }
                else 
                {
                    for (var j = 0; j < _matrix.GetLength(1); j++)
                    {
                        for (var k = j + 1; k < _matrix.GetLength(1); k++)
                        {
                            if (_matrix[i, k] > _matrix[i, j])
                            {
                                (_matrix[i, k], _matrix[i, j]) = (_matrix[i, j], _matrix[i, k]);
                            }
                        }
                    }
                }
                
            }

            Console.WriteLine("После сортировки");
            PrintMatrix();
        }

        public void Inversion()
        {
            Console.WriteLine("Перед инверсией:");
            PrintMatrix();

            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1) / 2; j++)
                {
                    (_matrix[i, j], _matrix[i, _matrix.GetLength(1) - 1 - j]) = (_matrix[i, _matrix.GetLength(1) - 1 - j], _matrix[i, j]);
                }
            }

            Console.WriteLine("После инверсии:");
            PrintMatrix();
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a._matrix.GetLength(0) != b._matrix.GetLength(0) || a._matrix.GetLength(1) != b._matrix.GetLength(1))
            {
                throw new ArgumentException($"Размеры матриц {nameof(a)} & {nameof(b)} не совпадают!");
            }

            var result = new Matrix(a._matrix.GetLength(0), a._matrix.GetLength(1));

            for (var i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (var j = 0; j < result._matrix.GetLength(1); j++)
                {
                    result._matrix[i ,j] = a._matrix[i, j] + b._matrix[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a._matrix.GetLength(0) != b._matrix.GetLength(0) || a._matrix.GetLength(1) != b._matrix.GetLength(1))
            {
                throw new ArgumentException($"Размеры матриц {nameof(a)} & {nameof(b)} не совпадают!");
            }

            var result = new Matrix(a._matrix.GetLength(0), a._matrix.GetLength(1));

            for (var i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (var j = 0; j < result._matrix.GetLength(1); j++)
                {
                    result._matrix[i, j] = a._matrix[i, j] - b._matrix[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a._matrix.GetLength(1) != b._matrix.GetLength(0))
            {
                throw new ArgumentException($"Матрицы {nameof(a)} & {nameof(b)} не совместны!");
            }

            var result = new Matrix(a._matrix.GetLength(0), b._matrix.GetLength(1));

            for (var i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (var j = 0; j < result._matrix.GetLength(1); j++)
                {
                    var sum = 0;

                    for (var k = 0; k < a._matrix.GetLength(1); k++)
                    {
                        sum += a._matrix[i, k] * b._matrix[k, j];
                    }

                    result._matrix[i, j] = sum;
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, int c)
        {
            var result = new Matrix(a._matrix.GetLength(0), a._matrix.GetLength(1));

            for (var i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (var j = 0; j < result._matrix.GetLength(1); j++)
                {
                    result._matrix[i, j] = c * a._matrix[i, j];
                }
            }

            return result;
        }

        public static Matrix operator /(Matrix a, int c)
        {
            if (c == 0)
            {
                throw new ArgumentException("Деление на ноль!");
            }

            var result = new Matrix(a._matrix.GetLength(0), a._matrix.GetLength(1));

            for (var i = 0; i < result._matrix.GetLength(0); i++)
            {
                for (var j = 0; j < result._matrix.GetLength(1); j++)
                {
                    result._matrix[i, j] = a._matrix[i, j] / c;
                }
            }

            return result;
        }

        public static int[] GetSize()
        {
            while (true)
            {
                Console.Write("Введите размер матрицы в формате n,m (n,m - натуральные числа): ");

                var sizeText = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(sizeText))
                {
                    Console.WriteLine("Вы ввели пустую строку или пробелы");
                    continue;
                }

                try
                {
                    var size = sizeText.Split(' ').Select(int.Parse).ToArray();

                    if (size.Length != 2)
                    {
                        Console.WriteLine("Вы ввели неверное количество размеров, и должно быть 2");
                        continue;
                    }

                    if (size[0] <= 0 || size[1] <= 0)
                    {
                        Console.WriteLine("Вы ввели неверные размеры они должны быть натуральными");
                        continue;
                    }

                    return size;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы ввели числа в неверном формате");
                }
            }
        }
    }
}