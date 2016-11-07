using System.Collections.Generic;
using TestApp.DAL.Infrastructure;
using TestApp.DAL.Model;
using TestApp.DAL.Repositrories;
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

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }
    }
}
