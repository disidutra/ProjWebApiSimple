using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiUser.Models;

namespace WebApiUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WebApiSimpleDbContext _context;

        public UserController(WebApiSimpleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            try
            {
                var result = await _context.Users.ToListAsync();
                if (result.Any())
                {
                    return result;                        
                }
                return NotFound();
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}