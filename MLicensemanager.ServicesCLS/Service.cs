using Microsoft.EntityFrameworkCore;
using MLicensemanager.SqlServerPlug.Data;
using Group = MLicensemanager.BusinessCore.Entities.Group;
namespace MLicensemanager.ServicesCLS
{
    public class Service
    {
        private readonly LMSDbContext _dbContext;

        public Service(LMSDbContext dbContext)
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