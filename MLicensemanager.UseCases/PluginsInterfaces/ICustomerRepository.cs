using MLicensemanager.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.PluginsInterfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByIdAsync(int customerId);
    }
}
