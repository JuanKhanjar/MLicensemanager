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
    public class GetProductsForCustomerAndGroupAsyncUC : IGetProductsForCustomerAndGroupAsyncUC
    {
        private readonly IProductRepositoy _productRepositoy;

        public GetProductsForCustomerAndGroupAsyncUC(IProductRepositoy productRepositoy)
        {
            _productRepositoy = productRepositoy;
        }
        public async Task<List<Product>> ExecuteAsync(int customerId, int groupId)
        {
            return await _productRepositoy.GetProductsForCustomerAndGroupAsync(customerId, groupId);
        }
    }
}
