using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore;
using MLicensemanager.Services;
using MLicensemanager.SqlServerPlug.Data;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize DbContext
            var dbContextOptions = new DbContextOptionsBuilder<CLDbContext>()
                .UseSqlServer("Server=JUANWIN\\SQLEXPRESS;Database=CLMDataBase;Trusted_Connection=True;TrustServerCertificate=Yes")
                .Options;

            using var dbContext = new CLDbContext(dbContextOptions);
            Service service = new Service(dbContext);
            // Call the service method
            int customerId = 1;
            var productsByGroup = await service.GetProductsByGroupForCustomerAsync(customerId);

            foreach (var group in productsByGroup)
            {
                Console.WriteLine($"Group Name: {group.Key}");

                foreach (var product in group)
                {
                    Console.WriteLine($"   Product: {product.Products.Count}");
                    foreach (var p in product.Products)
                    {
                        Console.WriteLine($"   Product: {product.Products}");
                    }
                }
            }
        }
    }
}