using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestApp.API.Model;
using TestApp.DAL.Model;
using TestApp.ServiceContracts;

namespace TestApp.API.Controller
{
    [Route("api/orders")]
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
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
            _orderService.SaveOrder();
            return CreatedAtRoute("GetPerson", new { id = order.Id }, order);
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson(int id)
        {
            return new OkObjectResult(_orderService.GetOrderById(id));
        }

        [HttpGet]
        public IActionResult GetListPersons([FromQuery]int pageNum, int pageSize, int? amountFilter)
        {
            var skipAmount = pageSize * (pageNum - 1);

            var totalPersons = _orderService.GetAll().Count();
            var totalPages = (int)Math.Ceiling((double)totalPersons / pageSize);
            var results = amountFilter == null
                ? _orderService.GetAll().Skip(skipAmount).Take(pageSize)
                : _orderService.GetAll(o => o.Amount == amountFilter).Skip(skipAmount).Take(pageSize);

            var pagedResult = new PagedResult<Order>
            {
                CurrentPage = pageNum,
                PageSize = pageSize,
                Results = results,
                TotalNumberOfItems = totalPersons,
                TotalNumberOfPages = totalPages
            };

            return new OkObjectResult(pagedResult);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] Order person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            var personToUpdate = _orderService.GetOrderById(id);
            if (personToUpdate == null)
            {
                return NotFound();
            }

            person.Id = personToUpdate.Id;

            _orderService.UpdateOrder(person);
            _orderService.SaveOrder();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _orderService.GetOrderById(id);
            if (person == null)
            {
                return BadRequest();
            }

            _orderService.RemoveOrder(person);
            _orderService.SaveOrder();
            return Ok();
        }
    }
}
