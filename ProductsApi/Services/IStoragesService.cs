using ProductsApi.Models;
using System.Xml.Linq;

namespace ProductsApi.Services
{
    public interface IStoragesService
    {
        public List<Storage> GetAll();
        public bool AddProduct(NewProductDto newProduct);
        public bool AddStorage(NewStorageDto newStorage);
        public void DeleteProduct(string productId);
        public void DeleteStorage(string storageName);
        public void Sell(string productId, int count);
        public decimal TotalWeight();
        public void Save();
    }
}
