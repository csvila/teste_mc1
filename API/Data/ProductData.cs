using API.Entities;
using System.Collections.Generic;

namespace API.Data
{
    public class ProductData
    {
        public IEnumerable<Product> Get()
        {
            var lstProduct = new List<Product>();

            // Executar 'select' no banco e mapear
            // Calcular a quantidade
            // Se quantidade > 0 então isMarketable = true

            return lstProduct;
        }

        public Product Get(int sku)
        {
            var product = new Product();

            // Executar 'select' no banco e mapear
            // Calcular a quantidade
            // Se quantidade > 0 então isMarketable = true

            return product;
        }

        public void Create(Product product)
        {
            // Executar 'insert' no banco
        }

        public void Update(Product product)
        {
            // Executar 'update' no banco
        }

        public void Delete(int sku)
        {
            // Executar 'delete' no banco
        }
    }
}