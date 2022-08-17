using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{
    public class AddSupplier
    {
        [MaxLength(50)]
        public string supplierName { get; set; }

        [MaxLength(50)]
        public string supplierPhone { get; set; }

        public int supplierNumber { get; set; }

        [MaxLength(100)]
        public string supplierLocation { get; set; }
    }
}
