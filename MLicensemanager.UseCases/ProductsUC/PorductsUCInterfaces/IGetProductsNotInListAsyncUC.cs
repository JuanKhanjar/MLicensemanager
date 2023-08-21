using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.UseCases.ProductsUC.PorductsUCInterfaces
{
    public interface IGetProductsNotInListAsyncUC
    {
        Task<List<Product>> ExecuteAsync(List<Product> CustomerListOfProducts, List<Product> ListProductFromDb);
    }
}