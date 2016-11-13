using Microsoft.AspNetCore.Mvc;
using QuickOrder.Entities;
using QuickOrder.Services.Contracts;

namespace QuickOrder.API.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody]Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            _orderService.AddOrder(order);
            _orderService.SaveChanges();
            return CreatedAtRoute("GetOrder", new { id = order.Id }, order);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult GetOrder(int id)
        {
            return new OkObjectResult(_orderService.GetOrderById(id));
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return new OkObjectResult(_orderService.GetAllOrders());
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var personToUpdate = _orderService.GetOrderById(id);
            if (personToUpdate == null)
            {
                return NotFound();
            }

            order.Id = personToUpdate.Id;

            _orderService.UpdateOrder(order);
            _orderService.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return BadRequest();
            }

            _orderService.DeleteOrder(order);
            _orderService.SaveChanges();
            return Ok();
        }
    }
}
