using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_productRepository.GetAll());
        }

        [HttpGet("GetAllWithCategory")]
        public IActionResult GetAllWithCategory()
        {
            return Ok(_productRepository.GetAll(include: product => product.Include(p => p.Category)));
        }

        [HttpGet("GetBy{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productRepository.Get(product => product.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]Product product)
        {
            return Ok(_productRepository.Add(product));
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody] Product product)
        {
            return Ok(_productRepository.Update(product));
        }


        [HttpDelete("DeleteBy{id}")]
        public IActionResult Delete(Guid id)
        {
            var product = _productRepository.Get(product => product.Id == id);
            if (product == null)
                return BadRequest("Product not found");
            return Ok(_productRepository.Delete(product));
        }
    }
}

