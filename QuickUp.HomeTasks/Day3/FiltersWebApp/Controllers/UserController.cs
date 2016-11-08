using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltersWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiltersWebApp.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception();
            return new OkObjectResult(new User {Username = "Yy", Password = "123"});
        }
    }
}
