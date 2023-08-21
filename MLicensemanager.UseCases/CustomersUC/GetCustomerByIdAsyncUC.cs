using Microsoft.VisualBasic;
using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.UseCases.CustomersUC.CustomerUCIntefaces;
using MLicensemanager.UseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.CustomersUC
{
    public class GetCustomerByIdAsyncUC : IGetCustomerByIdAsyncUC
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdAsyncUC(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> ExecuteAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }
    }
}
