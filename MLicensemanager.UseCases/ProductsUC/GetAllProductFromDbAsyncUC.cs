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
    public class GetAllProductFromDbAsyncUC : IGetAllProductFromDbAsyncUC
    {
        private readonly IProductRepositoy _productRepositoy;

        public GetAllProductFromDbAsyncUC(IProductRepositoy productRepositoy)
        {
            _productRepositoy = productRepositoy;
        }
        public async Task<List<Product>> ExecuteAsync()
        {
            return await _productRepositoy.GetAllProductsAsync();
        }
    }
}
