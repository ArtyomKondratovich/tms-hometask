using ProductsApi.Models;
using ProductsApi.Models.Dto;
using System.Xml.Linq;

namespace ProductsApi.Services
{
    public interface IStoragesService
    {
        public List<StorageModel> GetAll();
        public void AddProduct(NewProductDto newProduct);
        public bool AddStorage(NewStorageDto newStorage);
        public void DeleteProduct(DeleteProductDto deleteProduct);
        public void DeleteStorage(DeleteStorageDto deleteStorage);
        public void Sell(string productId, int count);
        public decimal TotalWeight();
    }
}
