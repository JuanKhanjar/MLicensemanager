using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.SqlServerPlug.DbContextConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = MLicensemanager.BusinessCore.Entities.Group;

namespace MLicensemanager.SqlServerPlug.Data
{
    public class LMSDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GroupProduct> GroupProducts { get; set; }

        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        {
        }

        public LMSDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new GroupsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new GroupProductConfiguration());

            // Add more configurations if needed
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //string connectionString = "Server=JUANWIN\\SQLEXPRESS;Database=CLMDataBase;Trusted_Connection=True;TrustServerCertificate=Yes;";

            //optionsBuilder.UseSqlServer(connectionString);
        }
    }


}
