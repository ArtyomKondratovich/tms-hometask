using ProductsApi.Models;
using ProductsApi.Models.Dto;
using System.Xml.Linq;

namespace ProductsApi.Services
{
    public interface IStoragesService
    {
        public List<ProductModel> GetAllProducts();
        public List<StorageModel> GetAllStorages();
        public StorageModel GetStorage(int id);
        public ProductModel GetProduct(int id);
        public Task AddProductAsync(NewProductDto newProduct);
        public Task AddStorageAsync(NewStorageDto newStorage);
        public Task DeleteProductAsync(DeleteProductDto deleteProduct);
        public Task DeleteStorageAsync(DeleteStorageDto deleteStorage);
        public void Sell(string productId, int count);
        public decimal TotalWeight();
    }
}
