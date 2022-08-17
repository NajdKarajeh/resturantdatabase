using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class Consuming
    {
        public int Id { get; set; }

        public DateTime ConsumingDate { get; set; }

        public int Count { get; set; }


        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Items item { get; set; }
    }
}
