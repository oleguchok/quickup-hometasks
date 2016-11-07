using System.Collections.Generic;

namespace TestApp.DAL.Model
{
    public class Person : IEntityBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
