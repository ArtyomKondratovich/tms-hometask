using ProductsApi.DataBase;
using ProductsApi.Models;
using ProductsApi.Models.Dto;
using ProductsApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ProductsApi.Services
{
    public class StoragesService : IStoragesService
    {

        private readonly ILogger<StoragesService> _logger;

        private readonly MyDbContext _dbContext;

        public StoragesService(MyDbContext dbContext, ILogger<StoragesService> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(NewProductDto newProduct)
        {
            var storage = await _dbContext.Storages.FindAsync(newProduct.StorageId);

            var exception = new CustomException
            {
                ErrorName = $"Non valid {nameof(ProductModel)}",
                Messages = new List<string>(),
                StatusCode = 400
            };

            if (string.IsNullOrWhiteSpace(newProduct.Name))
            {
                exception.Messages.Add(
                    $"{nameof(newProduct.Name)} can't be null or white spaces");
            }
            
            if (string.IsNullOrWhiteSpace(newProduct.Description))
            {
                exception.Messages.Add(
                    $"{nameof(newProduct.Description)} can't be null or white spaces");
            }
            
            if (newProduct.Count < 0)
            {
                exception.Messages.Add(
                    $"{nameof(newProduct.Count)} can't be less than zero");
            }
            
            if (newProduct.Weight <= 0f)
            {
                exception.Messages.Add(
                    $"{nameof(newProduct.Weight)} can't be less or equal zero");
            }
            
            if (storage == null)
            {
                exception.Messages.Add(
                    $"{nameof(newProduct.StorageId)} must linked to an exsting storage");
            }

            if (exception.Messages.Any())
            {
                throw exception;
            }

            var product = new ProductModel
            {
                Name = newProduct.Name,
                Description = newProduct.Description,
                Count = newProduct.Count,
                Weight = newProduct.Weight,
                Storage = storage
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                $"{product.Name} added to db successfully at {DateTime.Now}");
        }

        public async Task AddStorageAsync(NewStorageDto newStorage)
        {
            var exception = new CustomException 
            {
                ErrorName = "Null or white space storage name",
                Messages = new List<string>(),
                StatusCode = 400
            };

            if (string.IsNullOrWhiteSpace(newStorage.Name))
            {
                exception.Messages.Add(
                    $"{newStorage.Name} is null or white space");
                throw exception;
            }

            var storage = new StorageModel 
            {
                Name = newStorage.Name,
                Products = new List<ProductModel>()
            };

            await _dbContext.Storages.AddAsync(storage);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation(
                $"{storage.Name} added to db successfully at {DateTime.Now}");
        }

        public async Task DeleteProductAsync(DeleteProductDto deleteProduct)
        {
            var productToDelete = _dbContext.Products.Find(deleteProduct.Id);

            var exception = new CustomException
            {
                ErrorName = "product to delete not found",
                Messages = new List<string>(),
                StatusCode = 400
            };

            if (productToDelete == null)
            {
                exception.Messages.Add(
                    $"product with id = {deleteProduct.Id} not found");
                throw exception;
            }

            _dbContext.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation(
                $"{productToDelete} removed from db successfully at {DateTime.Now}");
        }

        public async Task DeleteStorageAsync(DeleteStorageDto deleteStorage)
        {
            var storageToDelete = _dbContext.Storages.Find(deleteStorage.Id);

            var exception = new CustomException 
            {
                ErrorName = "Storage to delete not found",
                Messages = new List<string>(),
                StatusCode = 400
            };

            if (storageToDelete == null)
            {
                exception.Messages.Add(
                    $"Storage with id = {deleteStorage.Id} not found");
                throw exception;
            }

            _dbContext.Storages.Remove(storageToDelete);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation(
                $"{storageToDelete} removed from db successfully at {DateTime.Now}");
        }

        public List<ProductModel> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public List<StorageModel> GetAllStorages()
        {
            var storages = _dbContext.Storages.ToList();

            foreach (var storage in storages)
            {
                storage.Products = _dbContext.Products.Where(p => p.Storage.Id == storage.Id).ToList();
            }

            return storages;
        }

        public ProductModel GetProduct(int id)
        {
            var product = _dbContext.Products.Find(id);

            var exception = new CustomException 
            {
                ErrorName = "No such product",
                Messages = new List<string>(),
                StatusCode = 400
            };

            if (product == null) 
            {
                exception.Messages.Add(
                    $"Product with id = {id} doesn't exist");
                throw exception;
            }

            return product;
        }

        public StorageModel GetStorage(int id)
        {
            var storage = _dbContext.Storages.Find(id);

            var exception = new CustomException
            {
                ErrorName = "No such storage",
                Messages = new List<string>(),
                StatusCode = 400
            };

            if (storage == null)
            {
                exception.Messages.Add(
                    $"storage with id = {id} doesn't exist");
                throw exception;
            }

            return storage;
        }

        public void Sell(string productId, int count)
        {
            throw new NotImplementedException();
        }

        public decimal TotalWeight()
        {
            return (decimal)_dbContext.Products.Sum(p => p.Weight);
        }
    }
}
