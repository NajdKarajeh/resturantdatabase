using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [MaxLength(50)]
        public string supplierName { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string supplierPhone { get; set; }

        public int supplierNumber { get; set; }

        [MaxLength(100)]
        public string supplierLocation { get; set; }

        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
