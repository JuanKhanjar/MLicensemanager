using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.BusinessCore.Extensions;
using MLicensemanager.ServiceCLS;
using MLicensemanager.SqlServerPlug.Data;

namespace TestMyFunctionsConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Set up your DbContext
            var optionsBuilder = new DbContextOptionsBuilder<LMSDbContext>();
            optionsBuilder.UseSqlServer("your_connection_string_here");


            Console.WriteLine("Get Customer By Id Async.");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                var groupService = new MethodsTest(dbContext);

                int customerId = 1;
                Customer customer = await groupService.GetCustomerByIdAsync(customerId);

                if (customer != null)
                {
                    Console.WriteLine($"Customer Name: {customer.CustomerName}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Number Of Groups: ( {customer.Groups.Count()} )");
                    //foreach (var group in customer.Groups)
                    //{
                    //    Console.WriteLine($"Group Name: {group.GroupName}");
                    //    // Display other group information as needed
                    //}
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Get Groups With Products By CustomerId");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                var groupService = new MethodsTest(dbContext);

                int customerId = 1; // Replace with the actual customer ID
                var groupsWithProducts = await groupService.GetGroupsWithProductsByCustomerId(customerId);
                Console.WriteLine($"Number of Groups ( {groupsWithProducts.Count()} ) / Subtotal: {groupsWithProducts.CalculateSubtotal()}");

                foreach (var group in groupsWithProducts)
                {
                    Console.WriteLine($"Group: {group.GroupName} ----- EAN: {group.EAN}");
                    foreach (var groupProduct in group.GroupProducts)
                    {
                        Console.WriteLine($"Product: {groupProduct.Product.ProductName}, Cost: {groupProduct.Product.Price}, Quantity: {groupProduct.Quantity}, Total: {groupProduct.Quantity * groupProduct.Product.Price}");
                    }
                    Console.WriteLine($" --- Total Price: {group.CalculateTotalPrice()}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Update Product Quantity For Group And Customer Async");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                //var groupService = new MethodsTest(dbContext);

                //int groupId = 1; // Replace with the actual group ID
                //int customerId = 1; // Replace with the actual customer ID
                //int productId = 1; // Replace with the actual product ID
                //int newQuantity = 10; // Replace with the new quantity

                //await groupService.UpdateProductQuantityForGroupAndCustomerAsync(groupId, customerId, productId, newQuantity);
            }

            Console.WriteLine("");
            Console.WriteLine("Delete Product From Group For Customer Async");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                //var productService = new MethodsTest(dbContext);

                //int groupId = 1; // Replace with the actual group ID
                //int customerId = 1; // Replace with the actual customer ID
                //int productId = 1; // Replace with the actual product ID

                //await productService.DeleteProductFromGroupForCustomerAsync(groupId, customerId, productId);
            }

            Console.WriteLine("");
            Console.WriteLine("Update Product Quantities");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                //var productService = new MethodsTest(dbContext);

                //int customerId = 1; // Replace with the actual customer ID
                //int groupId = 1; // Replace with the actual group ID


                //// Given information: ProductId and new quantity
                //dynamic[] updates = new dynamic[]
                //  {
                //      new { ProductId = 1, NewQuantity = 2 },
                //      new { ProductId = 2, NewQuantity = 2 }
                //  };
                //Group? group = await productService.GetGroupWithProducts(groupId, customerId);
                //await productService.UpdateProductQuantities(groupId, customerId, updates);

                //Console.WriteLine("Changes saved successfully.");
            }

            Console.WriteLine("");
            Console.WriteLine("Get Products Not In List Async");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                var productService = new MethodsTest(dbContext);

                var customerListOfProducts = await productService.GetProductsForCustomerAndGroupAsync(1, 1);
                Console.WriteLine("Customer List Of Products------------------");
                foreach (var product in customerListOfProducts)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
                }

                Console.WriteLine("Product From Db------------------");
                var listProductFromDb = await productService.GetAllProductFromDbAsync();

                var productsNotInList = await productService.GetProductsNotInListAsync(customerListOfProducts, listProductFromDb);

                foreach (var product in productsNotInList)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Update GroupName For Customer And Group Async");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
            using (var dbContext = new LMSDbContext(optionsBuilder.Options))
            {
                var productService = new MethodsTest(dbContext);

                int customerId = 1; // Replace with the actual customer ID
                int groupId = 1;    // Replace with the actual group ID
                string newGroupName = "New Group Name"; // Replace with the new group name

                bool updateSuccess = await productService.UpdateGroupNameForCustomerAndGroupAsync(customerId, groupId, newGroupName);

                if (updateSuccess)
                {
                    Console.WriteLine("Group name updated successfully.");
                }
                else
                {
                    Console.WriteLine("Group not found.");
                }
            }

        }
    }
}