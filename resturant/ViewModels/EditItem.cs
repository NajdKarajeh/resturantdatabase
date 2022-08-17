using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{
    public class EditItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Description { get; set; }
        public int unitId { get; set; }

    }
}
