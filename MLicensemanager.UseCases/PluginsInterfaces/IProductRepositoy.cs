using MLicensemanager.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.PluginsInterfaces
{
    public interface IProductRepositoy
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductsForCustomerAndGroupAsync(int customerId, int groupId);
        Task<List<Product>> GetProductsNotInListAsync(List<Product> customerListOfProducts, List<Product> listProductFromDb);
    }
}
