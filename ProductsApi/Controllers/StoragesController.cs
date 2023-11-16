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
            return View("ListProducts", _service.GetAll());
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] NewProductDto newProduct)
        {
            _service.AddProduct(newProduct);
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public IActionResult AddStorage([FromForm] NewStorageDto newStorage)
        {
            if (_service.AddStorage(newStorage))
            {
                return RedirectToAction("GetAllProducts");
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromForm] DeleteProductDto deleteProduct)
        {
            _service.DeleteProduct(deleteProduct);
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public IActionResult DeleteStorage([FromForm] DeleteStorageDto deleteStorage)
        {
            _service.DeleteStorage(deleteStorage);
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult TotalWeight()
        {
            View("TotalWeight", _service.TotalWeight());

            return RedirectToAction("GetAllProducts");
        }
    }
}
