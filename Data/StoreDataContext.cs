using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;
using ProductCatalog.Data.Maps; 


namespace ProductCatalog.Data{

    public class StoreDataContext : DbContext {

        public DbSet<Product> Products {get; set;}

        public DbSet<Inventory> Inventories {get; set;}

        public DbSet<Warehouse> Warehouses {get; set;}

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
           optionsBuilder.UseSqlServer(@"Server=localhost\SQLSERVEREXPRESS;Database=CursoBalta;User ID=SA;Password=1q2w3e$$@;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new InventoryMap());
            builder.ApplyConfiguration(new WarehouseMap());

           
        }

    }

}