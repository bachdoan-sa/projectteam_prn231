using Microsoft.AspNetCore.Mvc;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _iOrderDetailService;
        public OrderDetailController(IOrderDetailService iOrderDetailService)
        {
            _iOrderDetailService = iOrderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _iOrderDetailService.GetAllOrderDetails();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var orderDetail = await _iOrderDetailService.GetOrderDetailById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetail orderDetail)
        {
            var createdOrderDetail = await _iOrderDetailService.CreateOrderDetail(orderDetail);
            return CreatedAtAction(nameof(GetById), new { id = createdOrderDetail.Id }, createdOrderDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest();
            }

            var result = await _iOrderDetailService.UpdateOrderDetail(orderDetail);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Order{id}")]
        public async Task<IActionResult> GetByOrderId(string id)
        {
            var orderDetail = await _iOrderDetailService.GetByOrderId(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }
    }
}
