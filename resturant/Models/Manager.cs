using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [MaxLength(50)]
        public string username { get; set; }

        [MaxLength(50)]
        public string password { get; set; }

        [MaxLength(100)]
        public string email { get; set; }

        [MaxLength(50)]
        public string phoneNumber { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
