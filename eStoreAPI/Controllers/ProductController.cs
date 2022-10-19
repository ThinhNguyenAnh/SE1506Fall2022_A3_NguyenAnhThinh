using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository = new ProductRepository();

        [HttpGet]
        public IEnumerable<Product> GetProducts() => repository.GetProducts();

        [HttpGet("categories")]
        public IEnumerable<Category> GetCategories() => repository.GetCategories();


        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            if (repository.InsertProduct(product) != null)
            {
                return Ok(product);
            };
            return BadRequest();
        }



        [Route("{id}")]
        [HttpGet]
        public IActionResult GetProductByID([FromRoute] int id)
        {
            var mem = repository.GetProductById(id);
            if (mem == null)
            {
                return NotFound();
            }
            return Ok(mem);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var p = repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            repository.DeleteProduct(p);
            return NoContent();
        }
        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateProduct([FromRoute] int id, Product p)
        {
            var tmp = repository.GetProductById(id);
            if (tmp == null)
            {
                return NotFound();
            }
            repository.UpdateProduct(p);
            return NoContent();
        }
    }
}
