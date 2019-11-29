using crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace crud.Interfaces
{
    /// <summary>
    /// CRUD Product
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();

        /// <summary>
        /// ProductRepository Constructor
        /// </summary>
        public ProductRepository()
        {
            List<Warehouse> wh = new List<Warehouse>
            {
                new Warehouse { locality = "SP", type = "ECOMMERCE", quantity = 1 },
                new Warehouse { locality = "RJ", type = "PHYSICAL_STORE", quantity = 2 },
                new Warehouse { locality = "SC", type = "ECOMMERCE", quantity = 3 },
                new Warehouse { locality = "RO", type = "PHYSICAL_STORE", quantity = 4 }
            };

            products.Add(new Product { SKU = "SKU1", Name = "Cell Phone", inventory = new Inventory {  Warehouses = wh } });
            products.Add(new Product { SKU = "SKU2", Name = "Car", inventory = new Inventory { Warehouses = wh } });
            products.Add(new Product { SKU = "SKU3", Name = "Table", inventory = new Inventory { Warehouses = wh } });
            products.Add(new Product { SKU = "SKU4", Name = "Notebook", inventory = new Inventory { Warehouses = wh } });
            products.Add(new Product { SKU = "SKU5", Name = "TV", inventory = new Inventory { Warehouses = wh } });
        }

        /// <summary>
        /// Lista Produtos
        /// </summary>
        /// <returns></returns>
        public List<Product> ListProducts()
        {
            //AQUI A LISTA VIRIA DO BANCO DE DADOS
            //List<Product> products = new List<Product>();
            return products;
        }

        public Product Get(string sku)
        {
            //BUSCA PRODUTO DO BANCO DE DADOS PELO SKU
            //return new Product();
            return products.FirstOrDefault(x => x.SKU == sku);
        }

        public List<Product> Add(Product product)
        {
            if (this.Get(product.SKU) != null)
                throw new Exception();
            else
            {
                //INSERE NO BANCO DE DADOS
                products.Add(product);
            }
            return products;
        }

        public List<Product> Update(string sku, Product product)
        {
            //ATUALIZA NO BANCO DE DADOS
            var itemIndex = products.FindIndex(p => p.SKU == sku);
            if (itemIndex >= 0)
            {
                product.SKU = sku;
                products[itemIndex] = product;
            }
            else
            { return null; }
            return products;
        }

        public List<Product> Delete(string sku)
        {
            //EXCLUI NO BANCO DE DADOS
            var itemIndex = products.FindIndex(p => p.SKU == sku);
            if (itemIndex >= 0)
            { products.RemoveAt(itemIndex); }
            
            return products;
        }

        
    }
}