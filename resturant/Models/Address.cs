using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [MaxLength(50)]
        public string city { get; set; }

        [MaxLength(100)]
        public string homeLocation { get; set; }
    }
}
