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
    public class AddressController : ControllerBase
    {
        private readonly MyDbContext _context;
        public AddressController(MyDbContext context)
        {
            _context = context;
        }



        [HttpGet("Get")]
        public async Task<IActionResult> GetAddress()
        {
           
           

            var Address = _context.Address.Select(s=>new { 
            
            s.AddressId,
            s.city,
            s.homeLocation,
            
            
            
            }).ToList();


            return Ok(Address);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddress add)
        {
            var address = new Address
            {
                city = add.city,
                homeLocation = add.homeLocation,
                
                
            };
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return Ok(address);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAddress([FromBody] EditAddress add)
        {
            var address = await _context.Address.AsNoTracking().Where(obj => obj.AddressId == add.addressId).FirstOrDefaultAsync();

            if(address == null)
            {
                return BadRequest("Invalid address");
            }

            var addressedit = new Address
            {
                city = add.city,
                homeLocation = add.homeLocation,
                

            };
            _context.Address.Update(addressedit);
            await _context.SaveChangesAsync();
            return Ok(addressedit);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            var address = await _context.Address.FirstOrDefaultAsync(obj => obj.AddressId == Id);

            if (address == null)
            {
                return BadRequest("Invalid address");
            }

            
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
