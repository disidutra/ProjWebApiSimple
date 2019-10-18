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

        public UserController(WebApiSimpleDbContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll(){
            var result = await _context.Users.ToListAsync();
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User item){

            await _context.AddAsync(item);
            return Ok();
        }

    }
}