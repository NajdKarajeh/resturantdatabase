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
    public class ItemsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ItemsController(MyDbContext context)
        {
            _context = context;
        }



        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var Items = _context.Items.Include(s=>s.unit).Select(s=>new { 
            
            s.Id,
            s.Name,
            s.Description,
                unit = s.unit != null ? new
                {
                    id = s.UnitId,
                    name = s.unit.Name,
                }:new Object { },
            
            
            
            }).ToList();


            return Ok(Items);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddItem model)
        {
            var item = new Items
            {
                Name = model.Name,
                Description=model.Description,
                UnitId=model.unitId
                
            };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EditItem model)
        {
            var item = _context.Items.FirstOrDefault(s => s.Id == model.Id);

            item.Name = model.Name;
            item.Description = model.Description;
            item.UnitId = model.unitId;
            _context.Items.Update(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

       


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(obj => obj.Id == Id);

            if (item == null)
            {
                return BadRequest("Invalid item");
            }

            
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
