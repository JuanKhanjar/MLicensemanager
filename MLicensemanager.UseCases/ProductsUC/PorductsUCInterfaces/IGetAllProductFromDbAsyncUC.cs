using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.UseCases.ProductsUC.PorductsUCInterfaces
{
    public interface IGetAllProductFromDbAsyncUC
    {
        Task<List<Product>> ExecuteAsync();
    }
}