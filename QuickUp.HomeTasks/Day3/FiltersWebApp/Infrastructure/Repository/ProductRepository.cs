using FiltersWebApp.Models;

namespace FiltersWebApp.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void Add(Product product)
        {
            _productContext.Add(product);
        }
    }
}
