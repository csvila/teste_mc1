using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Data.Maps{

    public class InventoryMap: IEntityTypeConfiguration<Inventory> {

        public void Configure(EntityTypeBuilder<Inventory> builder){

            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");


        }

    }
}