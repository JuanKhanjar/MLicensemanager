using Group= MLicensemanager.BusinessCore.Entities.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore.Extensions
{
    public static class GroupExtensions
    {
        public static decimal CalculateTotalPrice(this Group group)
        {
            decimal totalPrice = group.GroupProducts.Sum(gp => gp.Product.Price * gp.Quantity);
            return totalPrice;
        }

        public static decimal CalculateSubtotal(this IEnumerable<Group> groups)
        {
            decimal subtotal = groups.Sum(group => group.CalculateTotalPrice());
            return subtotal;
        }
    }
}
