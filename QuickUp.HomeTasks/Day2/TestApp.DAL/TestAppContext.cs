using Microsoft.EntityFrameworkCore;
using TestApp.DAL.Model;

namespace TestApp.DAL
{
    public class TestAppContext : DbContext
    {
        public TestAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
