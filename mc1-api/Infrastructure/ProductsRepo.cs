using System;
using System.Collections.Generic;
using System.Linq;
using mc1_api.Models;

namespace mc1_api.Infrastructure
{
    public class ProductsRepo
    {
        #region singleton
        private List<Product> Products { get; set; }

        private static ProductsRepo instance = null;

        private ProductsRepo()
        {
        }

        public static ProductsRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductsRepo();
                    instance.Products = new List<Product>();
                }
                return instance;
            }
        }
        #endregion

        public IList<Product> List()
        {
            return this.Products;
        }

        public Product Get(int sku)
        {
            return this.Products.SingleOrDefault(x => x.Sku == sku);
        }

        public void Add(Product product)
        {
            this.Products.Add(product);
        }

        internal void Delete(Product product)
        {
            if (product != null)
            {
                this.Products = this.Products
                .Where(x => x.Sku != product.Sku)
                .ToList();
            }
        }
    }
}