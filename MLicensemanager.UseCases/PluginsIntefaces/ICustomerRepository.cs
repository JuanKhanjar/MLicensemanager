using MLicensemanager.BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.PluginsIntefaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerWithGroupsAndLicensesAsync(int customerID);
    }
}
