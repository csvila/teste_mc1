using mc1_api.Domain.Interfaces;
using mc1_api.Infrastructure;
using mc1_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mc1_api.Domain
{
    public class ProductsDomain : IProductsDomain
    {
        public ProductsDomain()
        {
        }

        public IList<Product> GetAll()
        {
            var products = ProductsRepo.Instance.List();

            return products;
        }

        public Product GetBySKU(int sku)
        {
            var product = ProductsRepo.Instance.Get(sku);
            if (product?.Inventory.Warehouses.Count > 0)
            {
                product.Inventory.Quantity = product.Inventory.Warehouses.Sum(x => x.Quantity);
                product.isMarketable = product.Inventory.Quantity > 0;
            }

            return product;
        }

        public Product AddProduct(Product product)
        {
            var p = ProductsRepo.Instance.Get(product.Sku);
            if (p != null) return null;

            ProductsRepo.Instance.Add(product);
            return product;
        }

        public bool UpdateProduct(int sku, Product product)
        {
            var oldProduct = ProductsRepo.Instance.Get(sku);
            if (oldProduct == null) return false;

            ProductsRepo.Instance.Delete(oldProduct);
            ProductsRepo.Instance.Add(product);
            return true;
        }

        public bool DeleteProduct(int sku)
        {
            var product = ProductsRepo.Instance.Get(sku);
            if (product == null) return false;

            ProductsRepo.Instance.Delete(product);
            return true;
        }
    }
}