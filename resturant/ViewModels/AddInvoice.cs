using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{
    public class AddInvoice
    {
        public int supplierId { get; set; }
        //public double APDTotalCost { get; set; }
        //public double TotalOfPurchase { get; set; }

        public double totalPurchase { get; set; }
        public DateTime invoiceDate { get; set; }

        public IFormFile image { get; set; }

        //public  List<invoiceItems> items { get; set; }
        public  string items { get; set; }

    }


     public  class invoiceItems
    {
        public int itemId { get; set; }
        public double count { get; set; }
        public double discount { get; set; }
        public double apdTotalCost { get; set; }

        public double price { get; set; }

    }
}
