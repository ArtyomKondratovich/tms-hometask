using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandling
{
    internal class MatrixCalculator
    {
        private Stack<Matrix> _matrices { get; set; }
        private Stack<string> _operations { get; set; }
        public Dictionary<string, Matrix> _dictionary { get; set; }

        public MatrixCalculator() 
        {
            _matrices = new Stack<Matrix>();
            _operations = new Stack<string>();
            _dictionary = new Dictionary<string, Matrix>();
        }

        public Matrix Calculate(string expression) 
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException($"Введено пустое выражение {nameof(expression)}");
            }

            var splitExpression = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in splitExpression)
            {
                var priority = GetOperationPriority(item);

                if (priority > 0)
                {
                    while (!AddOperation(item))
                    {
                        MakeStep();
                    }
                }
                else 
                {
                    if (TryParse(item, out var matrix, out var scalar))
                    {
                        matrix *= scalar;
                        _matrices.Push(matrix);
                    }
                    else 
                    {
                        throw new ArgumentException($"Матрицы с именем {item} не существует в словаре");
                    }
                }
            }

            while (_operations.Count > 0)
            {
                MakeStep();
            }

            return _matrices.Pop();
        }

        public void MakeStep()
        {
            if (_operations.Count == 0 || _matrices.Count < 2)
            {
                throw new ArgumentException("Операций нет или количество матриц меньше 2");
            }

            var operation = _operations.Pop();
            var b = _matrices.Pop();
            var a = _matrices.Pop();

            _matrices.Push(operation switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                _ => throw new ArgumentException("Неверная операция")
            });
        }

        public static int GetOperationPriority(string operation)        /* if this operation returns priority, otherwise 0 */
        {
            return operation switch
            {
                "+" => 1,
                "-" => 1,
                "*" => 2,
                "/" => 2,
                _ => 0
            };
        }

        public bool TryParse(string s, out Matrix result, out int scalar)
        {
            scalar = s[0] == '-' ? -1 : 1;
            s = s.Trim('-');

            if (_dictionary.ContainsKey(s))
            {
                result = _dictionary[s];
                return true;
            }

            result = new Matrix();
            return false;
        }

        public bool AddOperation(string operation)                      /* true if addition is successful, otherwise false if you need make a step of calculation */
        {

            if (_operations.Count == 0)
            {
                _operations.Push(operation);
                return true;
            }

            var top = _operations.Peek();

            if (GetOperationPriority(top) > GetOperationPriority(operation))
            {
                return false;
            }

            _operations.Push(operation);
            return true;
        }
    }
}
