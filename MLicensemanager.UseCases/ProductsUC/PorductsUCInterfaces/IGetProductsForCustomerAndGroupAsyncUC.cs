using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.UseCases.ProductsUC.PorductsUCInterfaces
{
    public interface IGetProductsForCustomerAndGroupAsyncUC
    {
        Task<List<Product>> ExecuteAsync(int customerId, int groupId);
    }
}