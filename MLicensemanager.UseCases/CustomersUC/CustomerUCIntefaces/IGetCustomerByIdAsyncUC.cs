using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.UseCases.CustomersUC.CustomerUCIntefaces
{
    public interface IGetCustomerByIdAsyncUC
    {
        Task<Customer?> ExecuteAsync(int customerId);
    }
}