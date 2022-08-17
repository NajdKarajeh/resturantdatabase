using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class Items
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Units unit { get; set; }

    }
}
