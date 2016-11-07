using System.Collections.Generic;
using TestApp.DAL.Model;

namespace TestApp.ServiceContracts
{
    public interface IPersonService
    {
        Person GetPersonById(int id);
        IEnumerable<Person> GetAll();
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void RemovePerson(Person person);
        void SavePerson();
    }
}
