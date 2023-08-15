using MLicensemanager.BusinessCore;
using MLicensemanager.UseCases.CustomerUCases.UCIntefaces;
using MLicensemanager.UseCases.PluginsIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.CustomerUCases
{
    public class GetCustomerWithGroupsAndLicensesUC : IGetCustomerWithGroupsAndLicensesUC
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerWithGroupsAndLicensesUC(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> ExecuteAsync(int customerID)
        {
            return await _customerRepository.GetCustomerWithGroupsAndLicensesAsync(customerID);
        }
    }
}
