using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Models.Dto;
using ProductsApi.Services;
using ProductsApi.Views.Home;

namespace ProductsApi.Controllers
{
    public class StoragesController : Controller
    {
        private readonly IStoragesService _service;

        public StoragesController(IStoragesService service)
        {
            _service = service;
        }

        public IActionResult GetAllProducts()
        {
            return View("ListProducts", _service.GetAllProducts());
        }

        public IActionResult GetAllStorages()
        {
            return View("ListStorages", _service.GetAllStorages());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] NewProductDto newProduct)
        {
            await _service.AddProductAsync(newProduct);
            return RedirectToAction("GetAllStorages");
        }

        [HttpPost]
        public async Task<IActionResult> AddStorage([FromForm] NewStorageDto newStorage)
        {
            await _service.AddStorageAsync(newStorage);
            return RedirectToAction("GetAllStorages");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromForm] DeleteProductDto deleteProduct)
        {
            await _service.DeleteProductAsync(deleteProduct);
            return RedirectToAction("GetAllStorages");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStorage([FromForm] DeleteStorageDto deleteStorage)
        {
            await _service.DeleteStorageAsync(deleteStorage);
            return RedirectToAction("GetAllStorages");
        }

        public IActionResult TotalWeight()
        {
            return RedirectToAction("GetAllProducts");
        }
    }
}
