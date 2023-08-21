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

    public class GroupProductConfiguration : IEntityTypeConfiguration<GroupProduct>
    {
        public void Configure(EntityTypeBuilder<GroupProduct> builder)
        {
            builder.HasKey(gp => new { gp.GroupId, gp.ProductId });

            builder.Property(gp => gp.Quantity)
                .IsRequired();

            builder.HasOne(gp => gp.Group)
                .WithMany(g => g.GroupProducts)
                .HasForeignKey(gp => gp.GroupId)
                .OnDelete(DeleteBehavior.Cascade); // You can change the delete behavior as needed

            builder.HasOne(gp => gp.Product)
                .WithMany(p => p.GroupProducts)
                .HasForeignKey(gp => gp.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // You can change the delete behavior as needed

            // Seed data
            builder.HasData(
                new GroupProduct
                {
                    GroupId = 1, // Reference to an existing Group
                    ProductId = 1, // Reference to an existing Product
                    Quantity = 5
                },
                new GroupProduct
                {
                    GroupId = 1, // Reference to an existing Group
                    ProductId = 2, // Reference to an existing Product
                    Quantity = 3
                },
                new GroupProduct
                {
                    GroupId = 2, // Reference to an existing Group
                    ProductId = 1, // Reference to an existing Product
                    Quantity = 3
                }
            // Add more seed data if needed
            );
        }
    }

}
