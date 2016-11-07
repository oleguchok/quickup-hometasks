using Microsoft.AspNetCore.Mvc;
using TestApp.ServiceContracts;

namespace TestApp.API.Controller
{
    public class PersonController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("/persons")]
        public IActionResult ListPersons()
        {
            return new OkObjectResult(_personService.GetAll());
        }
    }
}
