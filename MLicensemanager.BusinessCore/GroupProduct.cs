using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.BusinessCore
{
    public class GroupProduct
    {
        [Key]
        public int Id { get; set; }
        public int GroupID { get; set; }
        public int ProductID { get; set; }
        public Group Group { get; set; }
        public Product Product { get; set; }
    }
}
