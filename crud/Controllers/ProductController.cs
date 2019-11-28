using crudrn.NET_WebApp.Interfaces;
using crudrn.NET_WebApp.Models;
using System.Web.Http;
using System.Web.Http.Results;

namespace crudrn.NET_WebApp.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository repositorio = new ProductRepository();

        // GET: api/Product
        public JsonResult<Product> Get(string sku)
        {
            //List<Product> products = repositorio.ListaProdutoPorSKU(sku);
            return Json(new Product());
        }

        // POST: api/Product
        public void Post([FromBody]Product product)
        {
            repositorio.Inserir(product);
        }

        // PUT: api/Product/5
        public void Put(string sku, [FromBody]Product product)
        {
            repositorio.Atualizar(sku, product);
        }

        // DELETE: api/Product/5
        public void Delete(string sku)
        {
            repositorio.Excluir(sku);
        }
    }
}
