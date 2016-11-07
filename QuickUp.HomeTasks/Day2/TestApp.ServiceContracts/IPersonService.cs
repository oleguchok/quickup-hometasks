using System.Collections.Generic;
using TestApp.DAL.Model;

namespace TestApp.ServiceContracts
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
    }
}
