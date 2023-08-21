using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Group Name is required")]
        [StringLength(100, ErrorMessage = "Group Name must be at most 100 characters")]
        public required string GroupName { get; set; }

        [StringLength(20, ErrorMessage = "EAN must be at most 20 characters")]
        public string EAN { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<GroupProduct> GroupProducts { get; set; }
        public Group()
        {
            GroupProducts = new List<GroupProduct>();
        }

        //public decimal CalculateTotalPriceForGroup(Group group)
        //{
        //    decimal totalPrice = group.GroupProducts.Sum(gp => gp.Product.Price * gp.Quantity);
        //    return totalPrice;
        //}

        //public decimal CalculateSubtotalForGroups(List<Group> groups)
        //{
        //    decimal subtotal = groups.Sum(group => CalculateTotalPriceForGroup(group));
        //    return subtotal;
        //}


    }
}
