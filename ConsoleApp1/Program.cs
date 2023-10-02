Console.WriteLine("Угадай число");

Console.WriteLine("Я загадал число от 1 до 10, попробуй угадать");
var hiddenNumber = (new Random()).NextInt64(1, 10);

while (true)
{
    try
    {
        var usersNumber = long.Parse(Console.ReadLine() ?? string.Empty);

        if (usersNumber == hiddenNumber)
        {
            Console.WriteLine("Круто, ты угадал!");
            break;
        }
        else if (usersNumber > 10 || usersNumber < 0)
        {
            Console.WriteLine("У тебя промежуток [1, 10]");
        }
        else if (usersNumber > hiddenNumber)
        {
            Console.WriteLine("Попробуй взять число поменьше");
        }
        else
        {
            Console.WriteLine("Попробуй взять число побольше");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Ты неправильно ввёл число");
    }
}

Console.ReadLine();