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
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public GroupRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<List<Group>> GetGroupsWithProductsByCustomerId(int customerId)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();
            var groupsWithProducts = await _dbContext.Groups
                .Include(g => g.GroupProducts)
                    .ThenInclude(gp => gp.Product)
                .Where(g => g.CustomerId == customerId)
                .ToListAsync();

            return groupsWithProducts;
        }

        public async Task<Group> GetGroupWithProductsByCustomerIdAndGroupId(int customerId, int groupId)
        {
            using var _dbContext = _dbContextFactory.CreateDbContext();

            var groupWithProducts = await _dbContext.Groups
                .Include(g => g.GroupProducts)
                    .ThenInclude(gp => gp.Product)
                .FirstOrDefaultAsync(g => g.CustomerId == customerId && g.GroupId == groupId);

            return groupWithProducts;
        }

    }
}
