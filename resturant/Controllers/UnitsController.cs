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
    public class UnitsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public UnitsController(MyDbContext context)
        {
            _context = context;
        }



        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var units = _context.Units.Select(s=>new { 
            
            s.Id,
            s.Name,
            s.IsNumber,
            
            
            }).ToList();


            return Ok(units);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddUnit model)
        {
            var unit = new Units
            {
                Name = model.Name,
                IsNumber=model.IsNumber,
                
            };
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();

            return Ok(unit);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EditUnit model)
        {
            var unit = _context.Units.FirstOrDefault(s => s.Id == model.Id);

            unit.Name = model.Name;
            unit.IsNumber = model.IsNumber;
            _context.Units.Update(unit);
            await _context.SaveChangesAsync();

            return Ok(unit);
        }

       


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var unit = await _context.Units.FirstOrDefaultAsync(obj => obj.Id == Id);

            if (unit == null)
            {
                return BadRequest("Invalid unit");
            }

            
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
