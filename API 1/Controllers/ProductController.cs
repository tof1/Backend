using API_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase

    {
        static List<Product> products = new List<Product>
        {
            new Product {Id = 1, Name = "Laptop", Description = "Laptop description.", Price = 999.9M },
            new Product {Id = 2, Name = "Smartphone", Price = 499.99M },
            new Product {Id = 3, Name = "Tablet", Price = 299.99M },
        };

        [HttpGet]

        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]

        public IActionResult GetProductById(int id)
        {
            var response = products.FirstOrDefault(p => p.Id == id);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct(int id, Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            products.Remove(existingProduct);

            return NoContent();

        }
    }
}
