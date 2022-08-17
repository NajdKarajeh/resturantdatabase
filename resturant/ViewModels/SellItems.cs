using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{

    public class sell
    {
        public DateTime date { get; set; }

        public List<SellItems> items { get; set; }
    }
    public class SellItems
    {
        public int itemId { get; set; }

        public double count { get; set; }

    }
}
