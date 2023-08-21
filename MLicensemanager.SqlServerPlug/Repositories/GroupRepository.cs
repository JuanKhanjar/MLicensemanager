using Microsoft.EntityFrameworkCore;
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
    public class GroupRepository : IGroupRepository
    {
        private readonly LMSDbContext _dbContext;

        public GroupRepository(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}
