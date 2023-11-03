using ProductsApi.Models;

namespace ProductsApi.Models
{
    public class StorageModel
    {
        public string Name { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
