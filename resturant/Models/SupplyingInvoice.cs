using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class SupplyingInvoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime invoiceDate { get; set; }

      

        public int supplierId { get; set; }

        


        

        public double TotalOfPurchase { get; set; }

        [MaxLength(50)]
        public string InvoiceStatus { get; set; }
        public string Url { get; set; }
        public bool Deleted { get; set; } = false;

        //public int SupplyingId { get; set; }
        //public Supplying Supplying { get; set; }
        public Supplier Supplier { get; set; }
      

        public  ICollection<InvoiceDetails> InvoiceDetails { get; set; } = new HashSet<InvoiceDetails>();

    }
}
