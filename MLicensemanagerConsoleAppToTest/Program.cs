using Microsoft.EntityFrameworkCore;
using MLicensemanager.ServicesCLS;
using MLicensemanager.SqlServerPlug.Data;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Set up your DbContext
        var optionsBuilder = new DbContextOptionsBuilder<LMSDbContext>();
        optionsBuilder.UseSqlServer("your_connection_string_here");

        using (var dbContext = new LMSDbContext(optionsBuilder.Options))
        {
            var groupService = new Service(dbContext);

            int customerId = 1; // Replace with the actual customer ID

            var groupsWithProducts = await groupService.GetGroupsWithProductsByCustomerId(customerId);

            foreach (var group in groupsWithProducts)
            {
                Console.WriteLine($"Group: {group.GroupName}");
                foreach (var groupProduct in group.GroupProducts)
                {
                    Console.WriteLine($"Product: {groupProduct.Product.ProductName}, Quantity: {groupProduct.Quantity}");
                }
                Console.WriteLine();
            }
        }
    }
}
