using ProductSolution.Domain.Entities;
using ProductSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductSolution.Domain
{
    public class Service : IService
    {
        private IRepository _repository; 
        public Product Create(Product product)
        {
            bool isAllReadyExists = _repository.Get(product.Sku) != null;
            if (isAllReadyExists)
                throw new Exception("Um produto com esse SKU já existe");
            return _repository.Create(product);
        }

        public void Delete(string sku)
        {
            _repository.Delete(sku);
        }

        public Product Get(string sku)
        {
            var result= _repository.Get(sku);
            result.Inventory.Quantity = result.Inventory.WareHouses.Sum(w => w.Quantity);
            result.IsMarketable = result.Inventory.Quantity > 0;
            return result;
        }

        public Product Update(string sku, Product product)
        {
            return _repository.Update(sku, product);
        }
    }
}
