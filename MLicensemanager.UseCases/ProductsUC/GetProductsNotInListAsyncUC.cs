using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.UseCases.PluginsInterfaces;
using MLicensemanager.UseCases.ProductsUC.PorductsUCInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.ProductsUC
{
    public class GetProductsNotInListAsyncUC : IGetProductsNotInListAsyncUC
    {
        private readonly IProductRepositoy _productRepositoy;

        public GetProductsNotInListAsyncUC(IProductRepositoy productRepositoy)
        {
            _productRepositoy = productRepositoy;
        }
        public async Task<List<Product>> ExecuteAsync(List<Product> CustomerListOfProducts, List<Product> ListProductFromDb)
        {
            return await _productRepositoy.GetProductsNotInListAsync(CustomerListOfProducts, ListProductFromDb);
        }
    }
}
