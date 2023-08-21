using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore;
using MLicensemanager.SqlServerPlug.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = MLicensemanager.BusinessCore.Group;

namespace MLicensemanager.Services
{
    public class Service
    {
        private readonly CLDbContext _dbContext;

        public Service(CLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<IGrouping<string, Group>>> GetProductsByGroupForCustomerAsync(int customerId)
        {
            return await _dbContext.Purchases
                .Where(p => p.CustomerId == customerId)
                .Select(p => p.Group)
                .GroupBy(g => g.Name)
                .ToListAsync();
        }

    }
}
