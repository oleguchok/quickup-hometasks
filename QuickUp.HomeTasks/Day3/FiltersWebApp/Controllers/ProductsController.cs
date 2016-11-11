using Microsoft.AspNetCore.Mvc;

namespace FiltersWebApp.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        public IActionResult Get()
        {
            return new OkResult();
        }
    }
}
