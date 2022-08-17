using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ResturantController : Controller
    {
        private readonly MyDbContext _context;
        public ResturantController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supp)
        {
            var supplier = new Supplier
            {
                supplierName = supp.supplierName,
                supplierPhone = supp.supplierPhone,
                supplierNumber = supp.supplierNumber,
                supplierLocation = supp.supplierLocation,
                ManagerId = supp.ManagerId,
                
            };
            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();

            return Ok(supplier);
        }

        [HttpPost("UpdateSupplier")]
        public async Task<IActionResult> UpdateSupplier([FromBody] Supplier supp)
        {
            var supplier1 = await _context.Supplier.AsNoTracking().Where(obj => obj.SupplierId == supp.SupplierId).FirstOrDefaultAsync();

            if(supplier1 == null)
            {
                return BadRequest("Invalid Supplier");
            }

            var supplier = new Supplier
            {
                SupplierId = supp.SupplierId,
                supplierName = supp.supplierName,
                supplierPhone = supp.supplierPhone,
                supplierNumber = supp.supplierNumber,
                supplierLocation = supp.supplierLocation,
                ManagerId = supp.ManagerId,

            };
            _context.Supplier.Update(supplier);
            await _context.SaveChangesAsync();
            return Ok(supplier);
        }
    }
}
