using ProductCatalog.Data;
using System.Collections.Generic;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProductCatalog.Repositories{

    public class ProductRepository{

        private readonly StoreDataContext _context;

        public ProductRepository(StoreDataContext context){

            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
                .Include(x => x.Warehouse) 
                .Select(x => new ListProductViewModel
                {
                    Sku = x.Sku,
                    Name = x.Name,
                    Inventory = x.Inventory.Quantity,
                    Warehouse = x.Warehouse.Locality,
                    
                })
                .AsNoTracking()
                .ToList(); 
        }

        public Product Get(int Sku){

            return _context.Products.Find(Sku);
        }

        public void Save(Product product){

            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public void Update(Product product) {


            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();


        }

        public void Delete(Product product) {


            _context.products.Delete(product);
            _context.SaveChanges();


        }


        
    }

}