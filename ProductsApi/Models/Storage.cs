using ProductsApi.Models;

namespace ProductsApi.Models
{
    public class Storage
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
