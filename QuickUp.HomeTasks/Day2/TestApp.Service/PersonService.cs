using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestApp.DAL.Infrastructure;
using TestApp.DAL.Model;
using TestApp.ServiceContracts;

namespace TestApp.Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IRepository<Person> personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public Person GetPersonById(int id) => _personRepository.GetById(id);

        public IEnumerable<Person> GetAll(Expression<Func<Person,bool>> where = null)
        {
            return where == null 
                ? _personRepository.GetAll() 
                : _personRepository.GetMany(where);
        }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (person.FirstName == null || person.LastName == null)
            {
                throw new ArgumentException();
            }

            _personRepository.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (person.FirstName == null || person.LastName == null)
            {
                throw new ArgumentException();
            }

            _personRepository.Update(person);
        }

        public void RemovePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _personRepository.Delete(person);
        }

        public void SavePerson() => _unitOfWork.Commit();
    }
}
