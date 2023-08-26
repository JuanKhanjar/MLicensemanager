using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.UseCases.CustomersUC.CustomerUCIntefaces;
using MLicensemanager.UseCases.PluginsInterfaces;

namespace MLicensemanager.UseCases.CustomersUC
{
    public class GetCustomerByIdAsyncUC : IGetCustomerByIdAsyncUC
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdAsyncUC(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Get A Spesific Customer With all his Gorups by customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>an object of Customer</returns>
        public async Task<Customer?> ExecuteAsync(int customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }
    }
}
