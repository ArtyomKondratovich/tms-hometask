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

        public IActionResult Index() 
        {
            return View();
        }
        
        public IActionResult GetAllProducts()
        {
            return View("ListProducts", _service.GetAll());
        }

        [HttpPost]
        public IActionResult AddProduct([FromForm] NewProductDto newProduct)
        {
            if (_service.AddProduct(newProduct))
            {
                return View("ListProducts", _service.GetAll());
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddStorage([FromForm] NewStorageDto newStorage)
        {
            if (_service.AddStorage(newStorage))
            {
                return View("ListProducts", _service.GetAll());
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromForm] DeleteProductDto deleteProduct)
        {
            _service.DeleteProduct(deleteProduct);
            return View("ListProducts", _service.GetAll());
        }

        [HttpPost]
        public IActionResult DeleteStorage([FromForm] DeleteStorageDto deleteStorage)
        {
            _service.DeleteStorage(deleteStorage);
            return View("ListProducts", _service.GetAll());
        }

        public IActionResult TotalWeight()
        {
            return View("ListProducts", _service.TotalWeight());
        }
    }
}
