using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.SqlServerPlug.Data;

namespace MLicensemanager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public CustomerController(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateGroupName(int id, [FromBody] string updatedGroup)
        {
            using LMSDbContext _dbContext=_dbContextFactory.CreateDbContext();
            var existingGroup = await _dbContext.Groups.FindAsync(id);
            if (existingGroup == null)
            {
                return NotFound();
            }

            existingGroup.GroupName = updatedGroup;
            await _dbContext.SaveChangesAsync();
            return Ok(existingGroup.GroupName);
        }
        [HttpGet()]
        public async Task<IActionResult> GetGroup()
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            var existingGroup = await _dbContext.Groups.ToListAsync();
            if (existingGroup == null)
            {
                return NotFound();
            }
            return Ok(existingGroup);
        }
        
    }
}
