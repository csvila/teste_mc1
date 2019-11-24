using ProductSolution.Domain.Entities;
using ProductSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSolution.Infra.Repository
{
    public class Repository : IRepository
    {
        public Product Create(Product product)
        {
            return product;
        }

        public void Delete(string sku)
        {

        }

        public Product Get(string sku)
        {
            return new Product { Sku = sku };
        }

        public Product Update(string sku, Product product)
        {
            return product;
        }
    }
}
