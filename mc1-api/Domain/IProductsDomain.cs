using System.Collections.Generic;
using mc1_api.Models;

namespace mc1_api.Domain.Interfaces
{
    public interface IProductsDomain
    {
        IList<Product> GetAll();
        Product GetBySKU(int sku);
        Product AddProduct(Product product);
        bool UpdateProduct(int sku, Product product);
        bool DeleteProduct(int sku);
    }
}