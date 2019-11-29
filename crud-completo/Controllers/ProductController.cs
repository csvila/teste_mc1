using crud.Interfaces;
using crud.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace crud
{
    /// <summary>
    /// Product Controller
    /// </summary>
    public class ProductController : ApiController
    {
        static readonly IProductRepository repositorio = new ProductRepository();

        //[HttpGet]
        /// <summary>
        /// GET Lista Clientes
        /// </summary>
        /// <returns></returns>
        public JsonResult<List<Product>> Get()
        {
            return Json(repositorio.ListProducts());
        }

        // GET: api/Product
        /// <summary>
        /// Get Method by SKY
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        [Route("api/Product/{sku}")]
        public JsonResult<Product> Get(string sku)
        {
            //List<Product> products = repositorio.ListaProdutoPorSKU(sku);
            return Json(repositorio.Get(sku));
        }

        // POST: api/Product
        /// <summary>
        /// Post Method
        /// </summary>
        /// <param name="product"></param>
        public void Post([FromBody]Product product)
        {
            repositorio.Add(product);
        }

        // PUT: api/Product/5
        /// <summary>
        /// Put Method
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="product"></param>
        public void Put(string sku, [FromBody]Product product)
        {
            repositorio.Update(sku, product);
        }

        // DELETE: api/Product/5
        /// <summary>
        /// Delete Methods
        /// </summary>
        /// <param name="sku"></param>
        public void Delete(string sku)
        {
            repositorio.Delete(sku);
        }
    }
}
