using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore
{
    public class CustomerGroup
    {
        [Key]
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public int GroupID { get; set; }

        public Customer Customer { get; set; }
        public Group Group { get; set; }
    }
}
