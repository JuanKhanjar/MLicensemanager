using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLicensemanager.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.SqlServerPlug.DbContextConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .IsRequired();
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)"); // Specify the appropriate precision and scale
            // Seed data
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Miralix Desktop 330",
                    Price = 10.99M
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Miralix Go 1.7",
                    Price = 20.99M
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Miralix Go 1.8",
                    Price = 21.99M
                }
            );
        }
    }

}
