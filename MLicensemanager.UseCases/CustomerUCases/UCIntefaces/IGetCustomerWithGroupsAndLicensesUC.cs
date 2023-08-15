using MLicensemanager.BusinessCore;

namespace MLicensemanager.UseCases.CustomerUCases.UCIntefaces
{
    public interface IGetCustomerWithGroupsAndLicensesUC
    {
        Task<Customer> ExecuteAsync(int customerID);
    }
}