using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickOrder.Entities;

namespace QuickOrder.DAL
{
    public class QuickOrderContext : IdentityDbContext<User, Role, int>
    {
        public QuickOrderContext(DbContextOptions options) : base(options) {}

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
