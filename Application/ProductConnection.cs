using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Repositories;
using ProductCatalog.Models;

public class ProductConnection : StoreDataContext<Product>
    {
        ProductRepository _data;

        public ProductConnection(ProductRepository repository)
        {
            _data = repository;
        }

        public async new Task<Product> GetById(int id)
        {
            var product = await base.GetById(id);

            if (product != null)
            {
                product.inventory.quantity = product.inventory.warehouses.Sum(x => x.quantity);
                
                product.isMarketable = product.inventory.quantity > 0;
                
                return product;
            }

            throw new ArgumentException("Product already exists in Sku context!");
        }
    }