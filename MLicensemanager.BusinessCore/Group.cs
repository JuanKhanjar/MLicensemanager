using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string EAN { get; set; }

        public ICollection<CustomerGroup> CustomerGroups { get; set; }
        public ICollection<GroupProduct> GroupProducts { get; set; }
    }
}
