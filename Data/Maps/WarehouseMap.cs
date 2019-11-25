using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Data.Maps{

    public class WarehouseMap: IEntityTypeConfiguration<Warehouse> {

        public void Configure(EntityTypeBuilder<Warehouse> builder){

            builder.ToTable("Warehouse");
            builder.HasKey(x => x.Type);
            builder.Property(x => x.Locality).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.HasOne(x => x.Products).WithMany(x => x.Warehouses);
       
        }

    }
}