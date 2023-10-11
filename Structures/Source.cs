
Hometask();
void Hometask()
{
    while (true)
    {
        var taskNumber = GetTaskNumber();
        switch (taskNumber)
        {
            case 1:
                Task1();
                break;
            case 2:
                Task2();
                break;
            case 4:
                Task4();
                break;
            case 5:
                Task5();
                break;
            case 6:
                Task6();
                break;
            case 7:
                Task7();
                break;
            case 0:
                return;
        }

    }
}

void Task1()
{
    Console.WriteLine("\nЗадание #1");
    Console.WriteLine("первые 11 членов последовательности Фибоначи");
    var fibonachi = new int[11];
    fibonachi[0] = 1;
    fibonachi[1] = 1;

    for (var i = 2; i < 11; i++)
    {
        fibonachi[i] = fibonachi[i - 1] + fibonachi[i - 2];
    }

    foreach (var number in fibonachi)
    {
        Console.Write($"{number} ");
    }
}

void Task2()
{
    Console.WriteLine("\nЗадание #2");
    var deposit = GetDeposit();
    var month = GetMonth();
    float factor = 1.07f;

    for (int i = 0; i < month; i++)
    {
        deposit *= factor;
    }

    Console.WriteLine($"\nКонечная сумма ппо истечению {month} месяцев = {deposit}");
}

void Task4()
{
    Console.WriteLine("\nЗадание #4");
    var rand = new Random();
    var n = GetN();
    var randomNumbers = new int[n];
    var evenNumbers = new List<int>();

    Console.WriteLine("\nМассив случайных целых");
    for (var i = 0; i < n; i++)
    {
        randomNumbers[i] = rand.Next(int.MinValue, int.MaxValue);
        if (randomNumbers[i] % 2 == 0)
        {
            evenNumbers.Add(randomNumbers[i]);
        }
        Console.Write($"{ randomNumbers[i] } ");
    }
    Console.WriteLine("\nМассив чётных:");

    foreach (var even in evenNumbers)
    {
        Console.Write($"{ even } ");
    }
}

void Task5()
{
    Console.WriteLine("\nЗадание #5");
    var numbers = new int[10];
    for (var i = 0; i < 10; i++)
    {
        numbers[i] = i * i + 2 * i - 1;
        Console.Write($"{numbers[i]} ");
    }

    Console.WriteLine();

    for (var i = 0; i < 10; i++)
    {
        numbers[i] = i % 2 == 1 ? 0 : numbers[i];
        Console.Write($"{numbers[i]} ");
    }

    Console.WriteLine();
}

void Task6()
{
    var names = GetNames();

    for (var i = 0;i < 5; i++)
    {
        for (var j = i + 1; j < 5; j++)
        {
            if (Compare(names[j], names[i]) < 0)
            {
                (names[i], names[j]) = (names[j], names[i]);
            }
        }
    }

    for (var i = 0; i < 5; i++)
    {
        Console.Write(names[i] + " ");
    }

    Console.WriteLine();
}

void Task7()
{
    var numbers = GetNumbers(12);

    for (var i = 0; i < 12; i++)
    {
        Console.Write($"{numbers[i]} ");
    }
    Console.WriteLine();

    for (var i = 0; i < 12; i++)
    {
        for (var j = i + 1; j < 12; j++)
        {
            if (numbers[j] < numbers[i])
            {
                (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
            }
        }
    }

    for (var i = 0; i < 12; i++)
    {
        Console.Write($"{numbers[i]} ");
    }
    Console.WriteLine();

}

int Compare(string str1, string str2)       /* 0 - for equal strings, 1 - when str1 > str2, -1 when str1 < str2*/
{
    int minLength = Math.Min(str1.Length, str2.Length);

    for (int i = 0; i < minLength; i++)
    {
        if (str1[i] < str2[i])
        {
            return -1;
        }
        else if (str1[i] > str2[i])
        {
            return 1;
        }
    }

    if (str1.Length < str2.Length)
    {
        return -1;
    }
    else if (str1.Length > str2.Length)
    {
        return 1;
    }
    else
    {
        return 0;
    }
}

string[] GetNames()
{
    Console.WriteLine("Введите 5 имён через пробел");
    while (true)
    {
        var namesText = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(namesText))
        {
            var names = namesText.Split(' ');
            if (names.Length == 5)
            {
                return names;
            }

            Console.WriteLine("Неверное количество имён");
            continue;
        }

        Console.WriteLine("Пустая строка или только пробелы");
    }
}

float GetDeposit()
{
    while (true)
    {
        Console.WriteLine("Введите сумму вашего вклада: ");
        if (float.TryParse(Console.ReadLine(), out var result) && result > 0)
        {
            return result;
        }
        else
        {
            Console.WriteLine("Вы ввели число неверного формата или <=0");
        }
    }
}

int GetN()
{
    while (true)
    {
        Console.WriteLine("Введите n (5 < n <= 10): ");
        if (int.TryParse(Console.ReadLine(), out var result) && result > 5 && result <= 10)
        {
            return result;
        }
        else
        {
            Console.WriteLine("Вы ввели число неверного формата или число не из полуинтревала (5,10]");
        }
    }
}

int GetMonth()
{
    while (true)
    {
        Console.WriteLine("Введите число месяцев: ");
        if (int.TryParse(Console.ReadLine(), out var result) && result > 0)
        {
            return result;
        }
        else
        {
            Console.WriteLine("Вы ввели число неверного формата или число <=0");
        }
    }
}

int[] GetNumbers(int n)
{
    var result = new int[n];

    while(true) 
    {
        Console.Write($"Введите {n} чисел через пробел: ");
        var line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine("Вы ввели пустую строку или только пробелы, попробуйте снова");
            continue;
        }

        try
        {
            var row = line.Split(' ').Select(int.Parse).ToArray();

            if (row.Length != n)
            {
                Console.WriteLine($"Вы ввели количество элементов != {n} попробуйте снова");
                continue;
            }

            for (var i = 0; i < n; i++)
            {
                result[i] = row[i];
            }

            return result;
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода, вы ввели неправильное число");
        }
    }
    
}

int GetTaskNumber()
{
    while (true)
    {
        Console.WriteLine("\nВведите номер задаания от 1 до 7 или 0 для выхода: ");
        if (int.TryParse(Console.ReadLine(), out var result) && result >= 0 && result <= 7)
        {
            return result;
        }
        else
        {
            Console.WriteLine("Вы ввели число неверного формата или число не от 1 до 6");
        }
    }
}