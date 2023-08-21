using MLicensemanager.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore.Helpers
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.ProductId == y.ProductId;
        }

        public int GetHashCode(Product obj)
        {
            return obj.ProductId.GetHashCode();
        }
    }
}
