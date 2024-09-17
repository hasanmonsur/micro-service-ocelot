using Microsoft.AspNetCore.Mvc;
using OrderService.Contacts;
using OrderService.Models;

namespace OrderService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            var result = await _orderRepository.AddOrder(order);
            if (result > 0) return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Order order)
        {
            order.Id = id;
            var result = await _orderRepository.UpdateOrder(order);
            if (result > 0) return NoContent();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteOrder(id);
            if (result > 0) return NoContent();
            return BadRequest();
        }
    }
}
