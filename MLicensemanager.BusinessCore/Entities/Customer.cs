using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore.Entities
{
    public class Customer
    {
        [Key] // Specifies that CustomerId is the primary key
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(100, ErrorMessage = "Customer Name must be at most 100 characters")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must be at most 100 characters")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email must be at most 100 characters")]
        [EmailAddress(ErrorMessage = "Email is not a valid email address")]
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Group> Groups { get; set; }

        public Customer()
        {
            // Initialize the collection in the constructor
            Groups = new List<Group>();
        }
    }
}
