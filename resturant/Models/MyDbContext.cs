using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Supplying> Supplying { get; set; }
        public DbSet<StockItems> StockItems { get; set; }
        public DbSet<SupplyingInvoice> SupplyingInvoice { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<SupplyingProcess> SupplyingProcess { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Sales> Sales { get; set; }

        //public DbSet<FullReport> FullReport { get; set; }


    }
}
