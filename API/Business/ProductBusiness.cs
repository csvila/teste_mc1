using API.Data;
using API.Entities;
using System.Collections.Generic;

namespace API.Business
{
    public class ProductBusiness
    {
        public IEnumerable<Product> Get()
        {
            var data = new ProductData();
            return data.Get();
        }

        public Product Get(int sku)
        {
            var data = new ProductData();
            return data.Get(sku);
        }

        public void Create(Product product)
        {
            var data = new ProductData();
            data.Create(product);
        }

        public void Update(Product product)
        {
            var data = new ProductData();
            data.Update(product);
        }

        public void Delete(int sku)
        {
            var data = new ProductData();
            data.Delete(sku);
        }
    }
}