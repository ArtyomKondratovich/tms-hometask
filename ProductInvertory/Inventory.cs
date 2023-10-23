using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInvertory
{
    internal class Inventory
    {
        public List<Product> Products { get; set; }

        public Inventory()
        {
            Products = new List<Product>();
        }

        public Inventory(List<Product> products) 
        {
            Products = products;
        }

        public bool AddProduct(Product product) 
        {
            var temp = Products.Find(x => x.Equals(product));

            if (temp != null)
            {
                temp.Amount++;
                return false;
            }
            
            Products.Add(product);

            return true;
        }

        public bool RemoveProduct(string name) 
        {
            var product = Products.Find(x => x.Name.Equals(name));

            if (product != null) 
            {
                Products.Remove(product);
                return true;
            }

            return false;
        }

        public bool SellProduct(Product product, int amount)
        {
            try
            {
                if (Products.Contains(product))
                {
                    product.Sell(amount);
                    return true;
                }

                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public bool IncreaseAmount(Product product, int amount)
        {
            try
            {
                if (Products.Contains(product))
                {
                    product.Add(amount);
                    return true;
                }

                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public decimal GetTotalPrice()
        {
            return Products.Sum(x => x.Price);
        }
    }
}