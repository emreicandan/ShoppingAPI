using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DTOs;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrdersController(IOrderRepository orderRepository,
            IProductTransactionRepository productTransactionRepository,
            IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _productTransactionRepository = productTransactionRepository;
            _orderDetailRepository = orderDetailRepository;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_orderRepository.GetAll());
        }

        [HttpGet("GetAllWithDetail")]
        public IActionResult GetAllWithDetail()
        {
            return Ok(_orderRepository.GetAll(include: order => order.Include(o => o.User)
            .Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
            .Include(o => o.OrderDetails).ThenInclude(od => od.ProductTransaction)));
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_orderRepository.Get(order => order.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]AddOrderDto addOrderDto)
        {
            if (addOrderDto.ProductTransactions.Count() == 0)
            {
                return BadRequest("Product List Connot Be Empty");
            };
            if(addOrderDto.ProductTransactions.Where(t=> t.Quantity == 0).Any())
            {
                return BadRequest("Product quantity connot be 0");
            }
            var checkCount = addOrderDto.ProductTransactions.Select(t => _productTransactionRepository.GetAll(pt => pt.ProductId == t.ProductId)
            .Sum(transaction => transaction.Quantity) - t.Quantity).Where(q => q < 0).Any();
            if (checkCount)
            {
                return BadRequest("not enough products in stock");
            }

            var addedOrder = _orderRepository.Add(new()
            {
                UserId = addOrderDto.UserId,
                CreatedDate = DateTime.UtcNow
            });
            addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
            {
                if (productTransaction.Quantity == 0) return;
                productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
                var addedProductTransaction = _productTransactionRepository.Add(productTransaction);
                _orderDetailRepository.Add(new()
                {
                    OrderId = addedOrder.Id,
                    ProductId = productTransaction.ProductId,
                    ProductTransactionId = productTransaction.Id
                });

            });
            return Ok(addedOrder);
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody]Order order)
        {
            return Ok(_orderRepository.Update(order));
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult Delete(Guid id)
        {
           var order = _orderRepository.Get(order => order.Id == id);
            if (order == null)
            return BadRequest("Order not found");
            return Ok(_orderRepository.Delete(order));
        }
    }
}

