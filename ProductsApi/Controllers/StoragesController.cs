using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StoragesController : ControllerBase
    {
        private readonly IStoragesService _service;
        public StoragesController(IStoragesService service)
        {
            _service = service;
        }

        [HttpPost]
        public IEnumerable<Storage> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] NewProductDto newProduct)
        {
            if (_service.AddProduct(newProduct))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddStorage([FromBody] NewStorageDto newStorage)
        {
            if (_service.AddStorage(newStorage))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromQuery] string productId)
        {
            _service.DeleteProduct(productId);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteStorage([FromQuery] string storageName)
        {
            _service.DeleteStorage(storageName);
            return Ok();
        }

        [HttpPost]
        public IActionResult TotalWeight()
        {
            return Ok(_service.TotalWeight());
        }

        [HttpPost]
        public IActionResult Save()
        {
            _service.Save();
            return Ok();
        }
    }
}
