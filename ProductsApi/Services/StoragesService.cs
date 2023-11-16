using ProductsApi.DataBase;
using ProductsApi.Models;
using ProductsApi.Models.Dto;
using ProductsApi.Exceptions;

namespace ProductsApi.Services
{
    public class StoragesService : IStoragesService
    {
        private readonly List<StorageModel> _storages;

        private readonly ILogger<StoragesService> _logger;

        private readonly IDataBase _dataBase;

        public StoragesService(ILogger<StoragesService> logger, IDataBase dataBase)
        {
            _logger = logger;
            _dataBase = dataBase;
            _storages = _dataBase.Read();
        }

        public List<StorageModel> GetAll()
        {
            return _storages.ToList();
        }

        public void AddProduct(NewProductDto newProduct)
        {
            var storage = _storages.Find(x => x.Name == newProduct.StorageName);

            if (storage != null)
            {
                var product = new ProductModel(
                    newProduct.Name,
                    newProduct.Description,
                    newProduct.Count,
                    newProduct.Weight);

                storage.Products.Add(product);
                _logger.LogInformation($"New product {product} added to storage {newProduct.StorageName}");
                Save();
                return;
            }

            throw new StorageNotFoundException(storageName: newProduct.StorageName);
        }

        public bool AddStorage(NewStorageDto newStorage)
        {
            var storage = _storages.Find(x => x.Name == newStorage.Name);

            if (storage != null)
            {
                _logger.LogInformation($"Storage {newStorage.Name} already exist");
            }
            else
            {
                _storages.Add(new StorageModel
                {
                    Name = newStorage.Name,
                    Products = new List<ProductModel>()
                });

                _logger.LogInformation($"Added new storage {newStorage.Name}");

                Save();

                return true;
            }

            return false;
        }

        public void DeleteProduct(DeleteProductDto deleteProduct)
        {
            var storage = _storages.Find(x => x.Products.Find(y => y.Id == deleteProduct.Id) != null);

            if (storage != null)
            {
                var product = storage.Products.Find(x => x.Id == deleteProduct.Id);

                if (product != null)
                {
                    storage.Products.Remove(product);
                    _logger.LogInformation($"Product {product} removed from storage {storage.Name}");
                    Save();
                }
                else
                {
                    _logger.LogInformation($"Product {product} not found in storage {storage.Name}");
                }
            }
            else
            {
                _logger.LogInformation($"Storage not found");
            }
        }

        public void DeleteStorage(DeleteStorageDto deleteStorage)
        {
            var storage = _storages.Find(x => x.Name == deleteStorage.StorageName);

            if (storage != null)
            {
                _storages.Remove(storage);
                _logger.LogInformation($"Storage {storage.Name} removed");
                Save();
            }
            else 
            {
                _logger.LogInformation($"Storage {deleteStorage.StorageName} didn't exist");
            }
        }

        public void Sell(string productId, int count)
        {
            var storage = _storages.Find(x => x.Products.Find(y => y.Id == productId) != null);

            if (storage != null)
            {
                var product = storage.Products.Find(x => x.Id == productId);

                if (product != null)
                {
                    product.Count = product.Count > count ? product.Count - count : 0;
                    _logger.LogInformation($"Sold {count} products {product}");
                    Save();
                }
                else
                {
                    _logger.LogInformation($"Product {product} not found in storage {storage.Name}");
                }
            }
            else
            {
                _logger.LogInformation($"Storage not found");
            }
        }

        public decimal TotalWeight()
        {
            return (decimal)_storages.Sum(x => x.Products.Sum(y => y.Weight));
        }

        private void Save()
        {
            _dataBase.Write(_storages);
        }
    }
}
