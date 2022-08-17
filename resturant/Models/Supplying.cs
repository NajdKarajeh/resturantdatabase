using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class Supplying
    {
        [Key]
        public int SupplyingId { get; set; }

        [MaxLength(50)]
        public int supplyingNumber { get; set; }

        public DateTime supplyingDate { get; set; }

        [MaxLength(100)]
        public string goodsName { get; set; }

        public int amount { get; set; }


        public int unitId { get; set; }
        public Units Unit { get; set; }

    }
}
