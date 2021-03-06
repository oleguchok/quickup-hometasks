﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestApp.API.Model;
using TestApp.DAL.Model;
using TestApp.ServiceContracts;

namespace TestApp.API.Controller
{
    [Route("api/persons")]
    public class PersonController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult CreatePerson([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            _personService.AddPerson(person);
            _personService.SavePerson();
            return CreatedAtRoute("GetPerson", new {id = person.Id}, person);
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson(int id)
        {
            return new OkObjectResult(_personService.GetPersonById(id));
        }

        [HttpGet]
        public IActionResult GetListPersons([FromQuery]int pageNum, int pageSize, string firstNameFilter)
        {
            var skipAmount = pageSize*(pageNum - 1);

            var totalPersons = _personService.GetAll().Count();
            var totalPages = (int)Math.Ceiling((double)totalPersons / pageSize);
            var results = firstNameFilter == null
                ? _personService.GetAll().Skip(skipAmount).Take(pageSize)
                : _personService.GetAll(p => p.FirstName == firstNameFilter).Skip(skipAmount).Take(pageSize);

            var pagedResult = new PagedResult<Person>
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
        public IActionResult UpdatePerson(int id, [FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            var personToUpdate = _personService.GetPersonById(id);
            if (personToUpdate == null)
            {
                return NotFound();
            }

            person.Id = personToUpdate.Id;

            _personService.UpdatePerson(person);
            _personService.SavePerson();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
            {
                return BadRequest();
            }

            _personService.RemovePerson(person);
            _personService.SavePerson();
            return Ok();
        }
    }
}
