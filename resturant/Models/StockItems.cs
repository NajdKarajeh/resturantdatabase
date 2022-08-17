using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class StockItems
    {
        [Key]
        public int StockId { get; set; }
        public int stockNumber { get; set; }

        public int ItemId { get; set; }

        public double storage { get; set; }

        [ForeignKey("ItemId")]
        public Items item { get; set; }
    }
}
