using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        public List<CustomerGroup> CustomerGroups { get; set; }
        public Customer()
        {
            CustomerGroups = new List<CustomerGroup>();
        }

    }
}
