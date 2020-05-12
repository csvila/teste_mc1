using API.Business;
using API.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/product")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage msg = null;

            var oBus = new ProductBusiness();

            try
            {
                var products = oBus.Get();
                msg = Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception ex)
            {
                msg = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                oBus = null;
            }

            return msg;
        }

        [HttpGet]
        [Route("api/product/{sku}")]
        public HttpResponseMessage Get(int sku)
        {
            HttpResponseMessage msg = null;

            var oBus = new ProductBusiness();

            try
            {
                if (sku == 0)
                {
                    throw new Exception("invalid sku");
                }

                var product = oBus.Get(sku);
                msg = Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception ex)
            {
                msg = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                oBus = null;
            }

            return msg;
        }

        [HttpPost]
        [Route("api/product")]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            HttpResponseMessage msg = null;

            var oBus = new ProductBusiness();

            try
            {
                //Verificar antes de incluir
                var productTest = oBus.Get(product.sku);
                if (productTest != null)
                {
                    msg = Request.CreateResponse(HttpStatusCode.BadRequest, "Product exists");
                }
                else
                {
                    oBus.Create(product);
                    msg = Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                oBus = null;
            }

            return msg;
        }

        [HttpPut]
        [Route("api/product")]
        public HttpResponseMessage Put([FromBody]Product product)
        {
            HttpResponseMessage msg = null;

            var oBus = new ProductBusiness();

            try
            {
                oBus.Update(product);
                msg = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                msg = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                oBus = null;
            }

            return msg;
        }

        [HttpDelete]
        [Route("api/product/{sku}")]
        public HttpResponseMessage Delete(int sku)
        {
            HttpResponseMessage msg = null;

            var oBus = new ProductBusiness();

            try
            {
                oBus.Delete(sku);
                msg = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                msg = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            finally
            {
                oBus = null;
            }

            return msg;
        }
    }
}