using TestApp.ServiceContracts;

namespace TestApp.API.Controller
{
    public class OrderController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}
