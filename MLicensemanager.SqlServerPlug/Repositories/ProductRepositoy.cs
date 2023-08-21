using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.BusinessCore.Helpers;
using MLicensemanager.SqlServerPlug.Data;
using MLicensemanager.UseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.SqlServerPlug.Repositories
{
    public class ProductRepositoy : IProductRepositoy
    {
        private readonly LMSDbContext _dbContext;

        public ProductRepositoy(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsForCustomerAndGroupAsync(int customerId, int groupId)
        {
            var products = await _dbContext.Groups
                .Where(g => g.CustomerId == customerId && g.GroupId == groupId)
                .SelectMany(g => g.GroupProducts.Select(gp => gp.Product))
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsNotInListAsync(List<Product> customerListOfProducts, List<Product> listProductFromDb)
        {
            var comparer = new ProductComparer();
            var productsNotInCustomerList = listProductFromDb.Except(customerListOfProducts, comparer).ToList();
            return productsNotInCustomerList;
        }
    }
}
