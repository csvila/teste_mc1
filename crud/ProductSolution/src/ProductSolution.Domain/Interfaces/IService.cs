using ProductSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSolution.Domain.Interfaces
{
    public interface IService
    {
        Product Create(Product product);
        Product Update(string sku, Product product);
        Product Get(string sku);
        void Delete(string sku);
    }
}
