using System;
using FiltersWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersWebApp.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception();
            return new OkObjectResult(new User {Username = "Yy", Password = "123"});
        }

        [HttpPost]
        public IActionResult Index([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
