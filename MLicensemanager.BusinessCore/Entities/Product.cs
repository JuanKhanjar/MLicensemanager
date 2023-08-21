using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        [StringLength(100, ErrorMessage = "ProductName must be at most 100 characters")]
        public required string ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public virtual ICollection<GroupProduct> GroupProducts { get; set; }
        public Product()
        {
            GroupProducts = new List<GroupProduct>();
        }
    }
}
