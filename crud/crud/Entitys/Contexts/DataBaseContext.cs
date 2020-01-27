using Microsoft.EntityFrameworkCore;

namespace crud.Entitys.Contexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {}

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
    }
}
