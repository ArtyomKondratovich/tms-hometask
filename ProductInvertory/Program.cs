using Microsoft.Extensions.Configuration;
using ProductInvertory;
using ProductInvertory.Loggers;
using System.IO;

try
{
    var path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\config.json");
    var config = new ConfigurationBuilder().AddJsonFile(path).Build();

    var settings = config.GetSection("Settings");

    var dataBase = new DataBase(settings["dataBasePath"]);

    ILogger logger = settings["loggerType"] switch
    {
        "console" => new ConsoleLogger(),
        "file" => new FileLogger(settings["loggerPath"]),
        _ => throw new InvalidOperationException()
    };

    var menu = new Menu(logger, dataBase);

    menu.Start();
}
catch 
{
    Console.WriteLine("Failed to configure the program");
}





