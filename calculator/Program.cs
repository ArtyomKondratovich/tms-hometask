using Calculator;

Calculator();

void Calculator()
{
    ReversePolishNotation reversePolishNotation = new ReversePolishNotation();
    PrintInstruction();

    while (true)
    {
        var inputExpression = GetExpression();

        switch (inputExpression)
        {
            case "e":
                return;
            case "c":
                Console.Clear();
                PrintInstruction();
                break;
            default:
                try
                {
                    if (reversePolishNotation.Validate(inputExpression))
                    {
                        Console.WriteLine(reversePolishNotation.Calculate()); 
                    }
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                
                break;
        }
    }
}

string GetExpression()
{
    while (true) 
    {
        Console.WriteLine("Введите выражение:");

        var inputExpression = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(inputExpression))
        {
            Console.WriteLine("Вы ввели пустую строку или только пробелы");
            continue;
        }

        return inputExpression;
    }
}

void PrintInstruction()
{
    Console.WriteLine("e -> exit from calculator\nc -> clear console");
}