using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductTransactionsController : Controller
    {
        private readonly IProductTransactionRepository _productTransactionRepository;

        public ProductTransactionsController(IProductTransactionRepository productTransactionRepository)
        {
            _productTransactionRepository = productTransactionRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_productTransactionRepository.GetAll());
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_productTransactionRepository.Get(productTransaction => productTransaction.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]ProductTransaction productTransaction)
        {
            return Ok(_productTransactionRepository.Add(productTransaction));
        }

        // PUT api/values/5
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ProductTransaction productTransaction)
        {
            return Ok(_productTransactionRepository.Update(productTransaction));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var productTransaction = _productTransactionRepository.Get(pt => pt.Id == id);
            if (productTransaction == null)
                return BadRequest("ProductTransaction not found");
            return Ok(_productTransactionRepository.Delete(productTransaction));
        }
    }
}

