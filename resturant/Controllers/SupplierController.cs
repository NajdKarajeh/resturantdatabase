using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturant.Models;
using resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SupplierController(MyDbContext context)
        {
            _context = context;
        }



        [HttpGet("test")]
        public IActionResult test()
        {
          
            var suppliers = _context.Supplier.Select(s=>new { 
            
            s.supplierName,
            s.SupplierId,
            s.supplierLocation,
            s.supplierNumber,
            s.supplierPhone,
            
            
            }).ToList();


            return Ok(suppliers);
        }
        [HttpGet("Get")]
        public IActionResult GetSupplier()
        {
            int mId = 0;
            string managerId = Request.Headers.GetCommaSeparatedValues("managerId").FirstOrDefault();
            try
            {
                mId = int.Parse(managerId);
            }
            catch (Exception)
            {

                return Unauthorized("You Are Not Authirizes");
            }
            var suppliers = _context.Supplier.Where(s=>s.ManagerId== mId).Select(s=>new { 
            
            s.supplierName,
            s.SupplierId,
            s.supplierLocation,
            s.supplierNumber,
            s.supplierPhone,
            
            
            }).ToList();


            return Ok(suppliers);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSupplier([FromBody] AddSupplier supp)
        {
            int mId = 0;
            string managerId = Request.Headers.GetCommaSeparatedValues("managerId").FirstOrDefault();
            try
            {
                mId = int.Parse(managerId);
            }
            catch (Exception)
            {

                return Unauthorized("You Are Not Authirizes");
            }
            var isExist = _context.Supplier.FirstOrDefault(s => s.supplierNumber == supp.supplierNumber || s.supplierPhone == supp.supplierPhone);
            if (isExist != null)
            {
                if (isExist.supplierPhone == supp.supplierPhone)
                {
                    return BadRequest("Phone Is Already Exist");
                }
                if (isExist.supplierNumber == supp.supplierNumber)
                {
                    return BadRequest("Supplier Number Is Already Exist");
                }

            }
            if(supp.supplierPhone.Length>10|| supp.supplierPhone.Length < 10)
            {
                return BadRequest("Phone Number Must Be 10 Digits");
            }
            var supplier = new Supplier
            {
                supplierName = supp.supplierName,
                supplierPhone = supp.supplierPhone,
                supplierNumber = supp.supplierNumber,
                supplierLocation = supp.supplierLocation,
                ManagerId = mId,
                
            };
            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();

            return Ok(supplier);
        }

        [HttpPut("Update")]
        public IActionResult UpdateSupplier([FromBody] EditSupplier supp)
        {

            var isExist = _context.Supplier.FirstOrDefault(s => (s.supplierNumber == supp.supplierNumber || s.supplierPhone == supp.supplierPhone) &&s.SupplierId!=supp.SupplierId);
            if (isExist != null)
            {
                if (isExist.supplierPhone == supp.supplierPhone)
                {
                    return BadRequest("Phone Is Already Exist");
                }
                if (isExist.supplierNumber == supp.supplierNumber)
                {
                    return BadRequest("Supplier Number Is Already Exist");
                }

            }
            if (supp.supplierPhone.Length > 10 || supp.supplierPhone.Length < 10)
            {
                return BadRequest("Phone Number Must Be 10 Digits");
            }
            var supplier1 =  _context.Supplier.FirstOrDefault(obj => obj.SupplierId == supp.SupplierId);

            if(supplier1 == null)
            {
                return BadRequest("Invalid Supplier");
            }


            supplier1.SupplierId = supp.SupplierId;
            supplier1.supplierPhone = supp.supplierPhone;
            supplier1.supplierName = supp.supplierName;
            supplier1.supplierNumber = supp.supplierNumber;
            supplier1.supplierLocation = supp.supplierLocation;

           
             _context.SaveChanges();
            return Ok(supplier1);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSupplier(int Id)
        {
            var supplier1 = await _context.Supplier.FirstOrDefaultAsync(obj => obj.SupplierId == Id);

            if (supplier1 == null)
            {
                return BadRequest("Invalid Supplier");
            }

            
            _context.Supplier.Remove(supplier1);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
