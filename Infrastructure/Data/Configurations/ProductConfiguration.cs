using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prop => prop.Id).IsRequired();
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(100);
            builder.Property(prop => prop.Description).IsRequired().HasMaxLength(180);
            builder.Property(prop => prop.Price).HasColumnType("decimal(18,2)");
            builder.Property(prop => prop.PictureUrl).IsRequired();
            builder.HasOne(prop => prop.ProductBrand).WithMany()
                .HasForeignKey(key => key.ProductBrandId);
            builder.HasOne(prop => prop.ProductType).WithMany()
                .HasForeignKey(key => key.ProductTypeId);
        }
    }
}
