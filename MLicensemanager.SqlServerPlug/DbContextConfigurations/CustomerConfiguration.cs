using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.SqlServerPlug.DbContextConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasAnnotation("RegularExpression", // Add a regular expression for email validation
                    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");

            // Seed data
            builder.HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "Vejle Kommune",
                    Address = "123 Main St",
                    Email = "vejle@example.com"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerName = "Vejen",
                    Address = "456 Elm St",
                    Email = "Vejen@example.com"
                }
            );
        }
    }
}
