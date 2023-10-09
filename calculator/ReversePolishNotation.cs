using System.Text.RegularExpressions;

namespace Calculator
{
    internal class ReversePolishNotation
    {
        private Stack<double> _values { get; set; }

        private Stack<char> _operations { get; set; }

        public ReversePolishNotation()
        {
            _values = new Stack<double>();
            _operations = new Stack<char>();
        }

        public double Calculate()
        {

            while (_operations.Count > 0)
            {
                var b  = _values.Pop();
                var a = _values.Pop();

                var operation = _operations.Pop();

                switch (operation)
                {
                    case '*':
                        a *= b;
                        break;
                    case '/':
                        if (b == 0)
                        {
                            throw new ArgumentException("Division by zero!");
                        }
                        a /= b;
                        break;
                    case '^':
                        a = Math.Pow(a, b);
                        break;
                    case '+':
                        a += b;
                        break;
                    case '-': 
                        a -= b;
                        break;
                }

                _values.Push(a);
            }
           
            return _values.Pop();
        }

        public void Operation(char operation)
        {
            var b = _values.Pop();
            var a = _values.Pop();

            switch (operation)
            {
                case '*':
                    a *= b;
                    break;
                case '/':
                    if (b == 0)
                    {
                        throw new ArgumentException("Division by zero!");
                    }
                    a /= b;
                    break;
                case '^':
                    a = Math.Pow(a, b);
                    break;
                case '+':
                    a += b;
                    break;
                case '-':
                    a -= b;
                    break;
            }

            _values.Push(a);
            _operations.Pop();
        }

        public bool Validate(string line)
        {
            _values.Clear();
            _operations.Clear();

            // Validate line
            line = Regex.Replace(line, @"\s", string.Empty);

            var start = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line.Length - 1 == i && double.TryParse(line[start..], out var parsed))
                {
                    _values.Push(parsed);
                }

                var priority = IsOperator(line[i]);
                if (priority != 0)
                {
                    if (double.TryParse(line[start..i], out var result))
                    {
                        _values.Push(result);

                        while (_operations.TryPeek(out var operation) && IsOperator(operation) < priority)
                        {
                            Operation(operation);
                        }

                        _operations.Push(line[i]);
                        
                        start = i + 1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return _values.Count - 1 == _operations.Count;
        }

        static int IsOperator(char c)           /* if c is operator return his priority else return 0 */ 
        {
            switch (c) 
            {
                case '+':
                case '-':
                    return 2;
                case '^':
                case '/':
                case '*':
                    return 1;
                default:
                    return 0;
            }
        }
    }
}