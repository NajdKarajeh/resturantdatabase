using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class FullReport
    {
        [Key]
        public int ReportId { get; set; }
        public DateTime supplyingDate { get; set; }

        [MaxLength(100)]
        public string goodsName { get; set; }

        [MaxLength(100)]
        public string supplierName { get; set; }

        public int storage { get; set; }


        public double EachSupplierTotal { get; set; }

        public double TotalOfPurchase { get; set; }


        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        public int InvoiceId { get; set; }
        public SupplyingInvoice SupplyingInvoice { get; set; }
    }
}
