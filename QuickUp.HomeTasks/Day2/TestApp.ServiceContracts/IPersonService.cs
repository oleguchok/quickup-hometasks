using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TestApp.DAL.Model;

namespace TestApp.ServiceContracts
{
    public interface IPersonService
    {
        Person GetPersonById(int id);
        IEnumerable<Person> GetAll(Expression<Func<Person,bool>> where = null);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void RemovePerson(Person person);
        void SavePerson();
    }
}
