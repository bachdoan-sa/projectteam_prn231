using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Models.OrderModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _iOrderService;
        public OrderController(IOrderService iOrderService)
        {
            _iOrderService = iOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _iOrderService.GetAllOrders();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var order = await _iOrderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderModel order)
        {
            var createdOrder = await _iOrderService.CreateOrder(order);
            if (createdOrder == null)
            {
                return BadRequest();
            }
            return Ok(createdOrder);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, OrderModel order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            var result = await _iOrderService.UpdateOrder(order);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Customer{id}")]
        public async Task<IActionResult> GetByCustomerId(string id)
        {
            var order = await _iOrderService.GetOrderByCustomerId(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
