using ProductsApi.DataBase;
using ProductsApi.Models;

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

        public bool AddProduct(NewProductDto newProduct)
        {
            var storage = _storages.Find(x => x.Name == newProduct.StorageName);

            if (storage != null)
            {
                try 
                {
                    var product = new ProductModel(newProduct.Name,
                        newProduct.Description,
                        newProduct.Count,
                        newProduct.Weight);

                    storage.Products.Add(product);
                    _logger.LogInformation($"New product {product} added to storage {newProduct.StorageName}");
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            }
            else
            {
                _logger.LogInformation($"Storage {storage} not found");
            }

            return false;
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

                return true;
            }

            return false;
        }

        public void DeleteProduct(string productId)
        {
            var storage = _storages.Find(x => x.Products.Find(y => y.Id == productId) != null);

            if (storage != null)
            {
                var product = storage.Products.Find(x => x.Id == productId);

                if (product != null)
                {
                    storage.Products.Remove(product);
                    _logger.LogInformation($"Product {product} removed from storage {storage.Name}");
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

        public void DeleteStorage(string storageName)
        {
            var storage = _storages.Find(x => x.Name == storageName);

            if (storage != null)
            {
                _storages.Remove(storage);
                _logger.LogInformation($"Storage {storage.Name} removed");
            }
            else 
            {
                _logger.LogInformation($"Storage {storageName} didn't exist");
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

        public void Save()
        {
            _dataBase.Write(_storages);
        }
    }
}
