using mc1_api.Infrastructure;
using mc1_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mc1_api.Domain
{
    public class ProductsDomain
    {
        public static IList<Product> GetAll()
        {
            var products = ProductsRepo.Instance.List();

            return products;
        }

        public static Product GetBySKU(int sku)
        {
            var product = ProductsRepo.Instance.Get(sku);
            if (product?.Inventory.Warehouses.Count > 0)
            {
                product.Inventory.Quantity = product.Inventory.Warehouses.Sum(x => x.Quantity);
                product.isMarketable = product.Inventory.Quantity > 0;
            }

            return product;
        }

        internal static Product AddProduct(Product product)
        {
            var p = ProductsRepo.Instance.Get(product.Sku);
            if (p != null) return null;

            ProductsRepo.Instance.Add(product);
            return product;
        }

        internal static bool UpdateProduct(int sku, Product product)
        {
            var oldProduct = ProductsRepo.Instance.Get(sku);
            if (oldProduct == null) return false;

            ProductsRepo.Instance.Delete(oldProduct);
            ProductsRepo.Instance.Add(product);
            return true;
        }

        internal static bool DeleteProduct(int sku)
        {
            var product = ProductsRepo.Instance.Get(sku);
            if (product == null) return false;

            ProductsRepo.Instance.Delete(product);
            return true;
        }
    }
}