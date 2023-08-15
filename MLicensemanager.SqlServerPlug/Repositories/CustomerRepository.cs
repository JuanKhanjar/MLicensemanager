using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore;
using MLicensemanager.SqlServerPlug.Data;
using MLicensemanager.UseCases.PluginsIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.SqlServerPlug.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CLDbContext _db;

        public CustomerRepository(CLDbContext db)
        {
            _db = db;
        }

        public async Task<Customer> GetCustomerWithGroupsAndLicensesAsync(int customerID)
        {
            return await _db.Customers
            .Include(c => c.CustomerGroups)
                .ThenInclude(cg => cg.Group)
                    .ThenInclude(g => g.GroupProducts)
                        .ThenInclude(gp => gp.Product)
            .SingleOrDefaultAsync(c => c.CustomerID == customerID);
        }
    }
}
