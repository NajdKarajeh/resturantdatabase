using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{
    public class AddAddress
    {
        [MaxLength(50)]
        public string city { get; set; }

        [MaxLength(50)]
        public string homeLocation { get; set; }

       
    }
}
