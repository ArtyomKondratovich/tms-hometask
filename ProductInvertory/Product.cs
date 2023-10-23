using ProductInvertory;
using System.Data;
using System.Runtime.CompilerServices;

namespace ProductInvertory
{
    internal class Product
    {
        public string Id { get; }

        public decimal Price { 
            get => _price;
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Price can not be negative");
                }

                _price = value;
            }
        }

        public int Amount {
            get => _amount;
            set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Amount can not be negative");
                }

                _amount = value;
            }
        }

        public string Name {
            get => _name;
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _name = value;
            }
                
        }

        private string _name;
        private decimal _price;
        private int _amount;

        public Product()
        {
            Id = Guid.NewGuid().ToString();
            _name = "";
            _price = 0;
            _amount = 0;
        }

        public Product(string id, string name, decimal price, int amount)
        {
            Id = id;
            _name = name;
            _price = price;
            _amount = amount;
        }

        public Product(string name, decimal price, int amount)
        {
             Id = Guid.NewGuid().ToString();
            _name = name;
            _price = price;
            _amount = amount;
        }

        public Product(string name)
        {
            Id = Guid.NewGuid().ToString();
            _name = name;
            _price = 0;
            _amount = 0;
        }

        public void Discount(int percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent));
            }

            _price *= percent / 100m;
        }

        public void Sell(int amount)
        {
            if (_amount - amount < 0)
            {
                throw new InvalidOperationException();
            }

            _amount -= amount;
        }

        public void Add(int amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException();
            }

            _amount += amount;
        }

        public override string ToString()
        {
            return $@"[{Id}, { _name }, { _price }, { _amount }]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Product item)
            {
                return false;
            }

            return this.Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}