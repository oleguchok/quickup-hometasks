using System.Collections.Generic;
using QuickOrder.Entities;

namespace QuickOrder.Services.Contracts
{
    public interface IProductService
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        void SaveChanges();
    }
}
