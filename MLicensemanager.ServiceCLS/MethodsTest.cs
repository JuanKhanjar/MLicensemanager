using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.BusinessCore.Helpers;
using MLicensemanager.SqlServerPlug.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.ServiceCLS
{
    public class MethodsTest
    {
        private readonly LMSDbContext _dbContext;

        public MethodsTest(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _dbContext.Customers
                .Include(c => c.Groups)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<List<Group>> GetGroupsWithProductsByCustomerId(int customerId)
        {
            var groupsWithProducts = await _dbContext.Groups
                .Include(g => g.GroupProducts)
                    .ThenInclude(gp => gp.Product)
                .Where(g => g.CustomerId == customerId)
                .ToListAsync();

            return groupsWithProducts;
        }

        public async Task UpdateProductQuantityForGroupAndCustomerAsync(int groupId, int customerId, int productId, int newQuantity)
        {
            var groupProduct = await _dbContext.GroupProducts
                .Include(gp => gp.Group)
                .FirstOrDefaultAsync(gp => gp.GroupId == groupId && gp.ProductId == productId && gp.Group.CustomerId == customerId);

            if (groupProduct != null)
            {
                groupProduct.Quantity = newQuantity;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                // Handle if the groupProduct was not found
            }
        }

        public async Task DeleteProductFromGroupForCustomerAsync(int groupId, int customerId, int productId)
        {
            var groupProduct = await _dbContext.GroupProducts
                .Include(gp => gp.Group)
                .FirstOrDefaultAsync(gp => gp.GroupId == groupId && gp.ProductId == productId && gp.Group.CustomerId == customerId);

            if (groupProduct != null)
            {
                _dbContext.GroupProducts.Remove(groupProduct);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                // Handle if the groupProduct was not found
            }
        }
       
        public async Task UpdateProductQuantities(int groupId, int customerId, dynamic[] updates)
        {
            Group? group = await GetGroupWithProducts(groupId, customerId);

            if (group != null)
            {
                foreach (var update in updates)
                {
                    UpdateProductQuantity(group, update.ProductId, update.NewQuantity);
                }

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Group not found.");
            }
        }
        // Update product quantity within the group
        public void UpdateProductQuantity(Group group, int productId, int newQuantity)
        {
            var groupProduct = group.GroupProducts.FirstOrDefault(gp => gp.ProductId == productId);

            if (groupProduct != null)
            {
                groupProduct.Quantity = newQuantity;
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found in the group.");
            }
        }
        public async Task<Group?> GetGroupWithProducts(int groupId, int customerId)
        {
            return await _dbContext.Groups
                            .Include(g => g.GroupProducts)
                            .FirstOrDefaultAsync(g => g.GroupId == groupId && g.CustomerId == customerId);
        }

        //Compare to lists 
        /// <summary>
        /// Retrieves a list of products for a specific customer and group.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns>A list of products associated with the specified customer and group.</returns>
        public async Task<List<Product>> GetProductsForCustomerAndGroupAsync(int customerId, int groupId)
        {
            var products = await _dbContext.Groups
                .Where(g => g.CustomerId == customerId && g.GroupId == groupId)
                .SelectMany(g => g.GroupProducts.Select(gp => gp.Product))
                .ToListAsync();

            return products;
        }


        /// <summary>
        /// Retrieves a list of all products from the database asynchronously.
        /// </summary>
        /// <returns>A list of all products from the database.</returns>
        public async Task<List<Product>> GetAllProductFromDbAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }


        /// <summary>
        /// Retrieves a list of products from <paramref name="ListProductFromDb"/> that are not present in <paramref name="CustomerListOfProducts"/>.
        /// </summary>
        /// <param name="CustomerListOfProducts">The list of products from the customer.</param>
        /// <param name="ListProductFromDb">The list of products from the database.</param>
        /// <returns>A list of products that are in <paramref name="ListProductFromDb"/> but not in <paramref name="CustomerListOfProducts"/>.</returns>
        /// <example>
        /// <code>
        /// var productService = new ProductService();
        ///
        /// // Simulate lists of products
        /// var customerListOfProducts = new List&lt;Product&gt;
        /// {
        ///     new Product { ProductId = 1, ProductName = "Product A" },
        ///     new Product { ProductId = 2, ProductName = "Product B" }
        /// };
        ///
        /// var listProductFromDb = new List&lt;Product&gt;
        /// {
        ///     new Product { ProductId = 1, ProductName = "Product A" },
        ///     new Product { ProductId = 2, ProductName = "Product B" },
        ///     new Product { ProductId = 3, ProductName = "Product C" }
        /// };
        ///
        /// var productsNotInList = await productService.GetProductsNotInListAsync(customerListOfProducts, listProductFromDb);
        ///
        /// Console.WriteLine("Products not in customer list:");
        /// foreach (var product in productsNotInList)
        /// {
        ///     Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}");
        /// }
        /// </code>
        /// </example>
        public async Task<List<Product>> GetProductsNotInListAsync(List<Product> CustomerListOfProducts, List<Product> ListProductFromDb)
        {
            var comparer = new ProductComparer();
            var productsNotInCustomerList = await Task.Run(() => ListProductFromDb.Except(CustomerListOfProducts, comparer).ToList());
            return productsNotInCustomerList;
        }

        // Update Group
        public async Task<bool> UpdateGroupNameForCustomerAndGroupAsync(int customerId, int groupId, string newGroupName)
        {
            var groupToUpdate = await _dbContext.Groups
                .FirstOrDefaultAsync(g => g.CustomerId == customerId && g.GroupId == groupId);

            if (groupToUpdate != null)
            {
                groupToUpdate.GroupName = newGroupName;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false; // Group not found
        }
    }
}
