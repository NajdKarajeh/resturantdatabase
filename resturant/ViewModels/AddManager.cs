using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.ViewModels
{
    public class AddManager
    {
        [MaxLength(100)]
        public string userName { get; set; }


        [MaxLength(100)]
        public string email { get; set; }

        [MaxLength(50)]
        public string password { get; set; }

        public string phoneNumber { get; set; }

        public int AddressId { get; set; }


    }
}
