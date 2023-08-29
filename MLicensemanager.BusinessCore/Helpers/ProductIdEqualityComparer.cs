using MLicensemanager.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore.Helpers
{
    public class ProductIdEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) // Check for reference equality
                return true;

            if (x is null || y is null) // Use pattern matching
                return false;

            return x.ProductId == y.ProductId;
        }

        public int GetHashCode(Product obj)
        {
            if (obj is null)
                return 0;

            return obj.ProductId.GetHashCode();
        }
    }
}
