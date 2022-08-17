using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class InvoiceDetails
    {
        public int Id { get; set; }

        public double Count { get; set; }

        public double Price { get; set; }
        public double APDTotalCost { get; set; }
        public double discount { get; set; }


        public int MainId { get; set; }
        [ForeignKey("MainId")]
        public SupplyingInvoice Invoice { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Items item { get; set; }




    }
}
