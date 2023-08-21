using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = MLicensemanager.BusinessCore.Entities.Group;

namespace MLicensemanager.SqlServerPlug.DbContextConfigurations
{
    public class GroupsConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.GroupId);

            builder.Property(g => g.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.EAN)
                .HasMaxLength(20);

            builder.HasOne(g => g.Customer)
                .WithMany(c => c.Groups)
                .HasForeignKey(g => g.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // You can change the delete behavior as needed

            // Seed data
            builder.HasData(
                new Group
                {
                    GroupId = 1,
                    GroupName = "Sundhed",
                    EAN = "EAN123",
                    CustomerId = 1 // Reference to an existing Customer
                },
                new Group
                {
                    GroupId = 2,
                    GroupName = "Borgerservice",
                    EAN = "EAN456",
                    CustomerId = 1 
                },
                new Group
                {
                    GroupId = 3,
                    GroupName = "Raadhus",
                    EAN = "EAN567",
                    CustomerId = 1 // Reference to an existing Customer
                },
                new Group
                {
                    GroupId = 4,
                    GroupName = "Sundhed",
                    EAN = "EAN789",
                    CustomerId = 2 // Reference to an existing Customer
                }
            );
        }
    }

}
