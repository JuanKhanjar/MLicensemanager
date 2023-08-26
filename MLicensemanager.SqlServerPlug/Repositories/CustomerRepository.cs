using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.SqlServerPlug.Data;
using MLicensemanager.UseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.SqlServerPlug.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(IDbContextFactory<LMSDbContext> dbContextFactory, ILogger<CustomerRepository> logger)
        {
            _dbContextFactory = dbContextFactory;
            _logger = logger;
        }

        public async Task<Customer?> GetCustomerByIdAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();

            try
            {
                return await _dbContext.Customers
                    .Include(c => c.Groups) // Eager loading related groups
                    .ThenInclude(g => g.GroupProducts) // Eager loading related products within groups
                    .ThenInclude(gp=>gp.Product)
                    .FirstOrDefaultAsync(c => c.CustomerId == customerId);
            }
            catch (DbException dbEx)
            {
                // Log the Db-related exception
                _logger.LogError(dbEx, "Database exception occurred while retrieving customer by ID: {CustomerId}", customerId);

                // Return a default value (or null) indicating that an error occurred
                return null;
            }
            catch (Exception ex)
            {
                // Log other exceptions
                _logger.LogError(ex, "An exception occurred while retrieving customer by ID: {CustomerId}", customerId);

                // Rethrow the exception if you want to handle other exceptions at a higher level
                throw;
            }
        }

    }
}
