﻿using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.SqlServerPlug.Data;
using MLicensemanager.UseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.SqlServerPlug.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LMSDbContext _dbContext;

        public CustomerRepository(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _dbContext.Customers
                .Include(c => c.Groups)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}
