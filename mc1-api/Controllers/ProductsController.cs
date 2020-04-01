using System.Collections.Generic;
using mc1_api.Domain;
using mc1_api.Domain.Interfaces;
using mc1_api.Infrastructure;
using mc1_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace mc1_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsDomain _productsDomain;

        public ProductsController(IProductsDomain productsDomain)
        {
            _productsDomain = productsDomain;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productsDomain.GetAll();
            return Ok(products);
        }

        [HttpGet("{sku}")]
        public ActionResult<string> Get(int sku)
        {
            var product = _productsDomain.GetBySKU(sku);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            var insertedProduct = _productsDomain.AddProduct(product);
            if (insertedProduct != null)
                return Created($"/products/{product.Sku}", insertedProduct);

            return BadRequest("SKU já cadastrado");
        }

        [HttpPut("{sku}")]
        public ActionResult Put(int sku, [FromBody] Product product)
        {
            bool updated = _productsDomain.UpdateProduct(sku, product);
            if (updated)
                return Ok();

            return NotFound();
        }

        [HttpDelete("{sku}")]
        public ActionResult Delete(int sku)
        {
            bool deleted = _productsDomain.DeleteProduct(sku);
            if (deleted)
                return Ok();

            return NotFound();
        }
    }
}
