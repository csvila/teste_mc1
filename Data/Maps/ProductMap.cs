using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;


namespace ProductCatalog.Data.Maps{


        public class ProductMap : IEntityTypeConfiguration<Product>{

            public void Configure(EntityTypeBuilder<Product> builder){

            builder.ToTable("Product");
            builder.HasKey(x => x.Sku);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");  
            builder.HasOne(x => x.Inventory).WithMany(x => x.Warehouses);

            }

        }


}