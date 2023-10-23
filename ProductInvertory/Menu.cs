using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ProductInvertory
{
    internal class Menu
    {
        private readonly ILogger _logger;

        private readonly Inventory _inventory;

        private readonly DataBase _dataBase;

        public Menu(ILogger logger, DataBase dataBase) 
        {
            _logger = logger;
            _dataBase = dataBase;
            _logger.Log("Loading data...", LogLevel.mInfo);
            _inventory = new Inventory
            {
                Products = _dataBase.LoadProducts()
            };
        }

        public void Start() 
        {
            Help();
            Product product;

            while (true)
            {
                var command = GetCommand();

                switch (command) 
                {
                    case "add":
                        product = GetProduct();

                        if (_inventory.AddProduct(product))
                        {
                            _logger.Log("New product added successfully", LogLevel.mInfo);
                        }
                        else 
                        {
                            _logger.Log("This product is already in inventory, the number of product units has been increased by 1", LogLevel.mInfo);
                        }
                        break;
                    case "remove":
                        var name = GetName();

                        if (_inventory.RemoveProduct(name))
                        {
                            _logger.Log("Product removed successfully", LogLevel.mInfo);
                        }
                        else 
                        {
                            _logger.Log("No such product", LogLevel.mInfo);
                        }
                        break;
                    case "total":
                        Console.WriteLine($"Total = {_inventory.GetTotalPrice()}");
                        break;
                    case "select all":
                        foreach (var item in _inventory.Products)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case "cls":
                        Console.Clear();
                        Help();
                        break;
                    case "exit":
                        Stop();
                        return;
                }
            }
        }

        public void Stop()
        {
            _logger.Log("Saving data...", LogLevel.mInfo);
            _dataBase.SaveProducts(_inventory.Products);
            _logger.Log("Data saved successfully", LogLevel.mInfo);
        }

        private static void Help()
        {
            Console.WriteLine(@"AddProduct - add,
RemoveProduct - remove,
CountTotal - total,
Select All - select all,
Clear - cls,
Exit - exit");
        }

        private static string GetCommand()
        {
            while (true) 
            {
                Console.Write("command >");
                var command = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(command))
                {
                    return command;
                }
            }
        }

        private static Product GetProduct()
        {
            while(true) 
            {
                Console.Write("Enter new product name, price, amount: ");

                var parametrsText = Console.ReadLine();

                if (parametrsText.TryParse(out var product) && product != null)
                {
                    return product;
                }
            }
        }

        private static string GetName()
        {
            while (true)
            {
                Console.Write("Введите название товара: ");

                var name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
            }
        }
    }
}
