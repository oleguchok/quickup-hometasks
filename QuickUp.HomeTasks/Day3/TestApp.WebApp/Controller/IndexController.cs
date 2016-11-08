using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestApp.WebApp.Controller
{
    [Route("api/index")]
    public class IndexController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger _logger;

        public IndexController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation(GetHashCode(), null, "nothing special");
            return Ok();
        }
    }
}
