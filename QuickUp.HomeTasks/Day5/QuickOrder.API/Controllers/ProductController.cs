using Microsoft.AspNetCore.Mvc;
using QuickOrder.Entities;
using QuickOrder.Services.Contracts;

namespace QuickOrder.API.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int productId)
        {
            return new OkObjectResult(_productService.GetProductById(productId));
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _productService.AddProduct(product);
            _productService.SaveChanges();
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return new OkObjectResult(_productService.GetProducts());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var personToUpdate = _productService.GetProductById(id);
            if (personToUpdate == null)
            {
                return NotFound();
            }

            product.Id = personToUpdate.Id;

            _productService.UpdateProduct(product);
            _productService.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return BadRequest();
            }

            _productService.DeleteProduct(product);
            _productService.SaveChanges();
            return Ok();
        }
    }
}
