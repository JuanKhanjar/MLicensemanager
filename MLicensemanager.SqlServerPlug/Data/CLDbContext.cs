using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = MLicensemanager.BusinessCore.Group;

namespace MLicensemanager.SqlServerPlug.Data
{
    public class CLDbContext:DbContext
    {
        public CLDbContext(DbContextOptions<CLDbContext> options):base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

            // Seed initial data
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, Title = "Aarhus Kommune",Adress="Agade 12",Email="a@gmail.com" },
                new Customer { CustomerID = 2, Title = "Vejle Kommune", Adress = "Vgade 12", Email = "v@gmail.com" }
            );

            modelBuilder.Entity<Group>().HasData(
                new Group { GroupID = 1, EAN = "19781",GroupName="Sundhed" },
                new Group { GroupID = 2, EAN = "19782", GroupName = "Borgerservice" },
                new Group { GroupID = 3, EAN = "19783",GroupName="Radhus" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Miralix Desktop 330", Price = 10.99M },
                new Product { ProductID = 2, Name = "Miralix Go 12", Price = 20.50M }
            );

            modelBuilder.Entity<CustomerGroup>().HasData(
                
                new CustomerGroup {Id=4, CustomerID = 2, GroupID = 2 },
                new CustomerGroup { Id = 5, CustomerID = 1, GroupID = 1 },
                new CustomerGroup { Id = 6, CustomerID = 1, GroupID = 2 },
                new CustomerGroup { Id = 7, CustomerID = 1, GroupID = 2 }
            );

            modelBuilder.Entity<GroupProduct>().HasData(
                new GroupProduct {Id=1, GroupID = 1, ProductID = 1 },
                new GroupProduct {Id=2, GroupID = 1, ProductID = 2 },
                new GroupProduct {Id=3, GroupID = 2, ProductID = 2 }
            );
        }
    }
}
