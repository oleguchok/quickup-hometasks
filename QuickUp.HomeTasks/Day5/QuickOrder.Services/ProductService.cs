using System.Collections.Generic;
using QuickOrder.DAL.Infrastructure;
using QuickOrder.Entities;
using QuickOrder.Services.Contracts;

namespace QuickOrder.Services
{
    public class ProductService : IProductService
    {
        private readonly IEntityBaseRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IEntityBaseRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> GetProducts() => _productRepository.GetAll();

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
