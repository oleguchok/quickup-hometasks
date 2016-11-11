using FiltersWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltersWebApp.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
