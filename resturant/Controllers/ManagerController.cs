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
    public class ManagerController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ManagerController(MyDbContext context)
        {
            _context = context;
        }



        [HttpGet("Get")]
        public async Task<IActionResult> GetManager()
        {
            var managers = _context.Manager.Select(s=>new { 
            
            s.phoneNumber,
            s.ManagerId,
            s.username,
            s.email,
           
            
            
            }).ToList();


            return Ok(managers);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AddManager supp)
        {
            var manager = new Manager
            {
                phoneNumber = supp.phoneNumber,
                email = supp.email,
                username = supp.userName,
                AddressId = supp.AddressId,
                password = supp.password,
                

            };
            _context.Manager.Add(manager);
            await _context.SaveChangesAsync();

            return Ok(manager);
        }



        [HttpPost("Login")]
        public  IActionResult Login([FromBody] Login login)
        {
            //ForTest
            //var managers = _context.Manager.ToList();
            //_context.Manager.RemoveRange(managers);
            //_context.SaveChanges();
            var manager = _context.Manager.FirstOrDefault(s => s.email == login.userName && s.password == s.password);
            if (manager == null)
            {
                return BadRequest("User Name Or Password Is InCorrect");

            }
            var result = new { 
            manager.ManagerId,
            manager.username
            };

            return Ok(result);
        }


    }
}
