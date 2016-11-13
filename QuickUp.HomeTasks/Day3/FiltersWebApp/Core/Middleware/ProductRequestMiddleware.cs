using System.Threading.Tasks;
using FiltersWebApp.Infrastructure.Repository;
using FiltersWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace FiltersWebApp.Core.Middleware
{
    public class ProductRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IProductRepository _productRepository;

        public ProductRequestMiddleware(RequestDelegate next, IProductRepository productRepository)
        {
            _next = next;
            _productRepository = productRepository;
        }

        public async Task Invoke(HttpContext context)
        {
            var clientIp = context.Request.Headers["ClientIp"];
            var referer = context.Request.Headers["HeaderReferer"];
            if (!string.IsNullOrEmpty(referer))
            {
                _productRepository.Add(new Product {IpAddress = clientIp, Referer = referer});
                await _next.Invoke(context);
            }
        }
    }
}
