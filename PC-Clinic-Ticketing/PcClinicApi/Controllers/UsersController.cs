using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace PcClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TicketingContext _context;

        public UsersController(TicketingContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users
        [HttpGet("/api/GetTechnicians")]
        public async Task<ActionResult<IEnumerable<User>>> GetTechnicians()
        {
            ActionResult<IEnumerable<User>> techs = await (from x in _context.Users
                                       where x.UserType == Models.User.UserTypes.Technician
                                       select x).ToListAsync();
            return techs;
        }

        // GET: api/Users
        [HttpGet("/api/GetCustomers")]
        public async Task<ActionResult<IEnumerable<User>>> GetCustomers()
        {
            ActionResult<IEnumerable<User>> customers = await (from x in _context.Users
                                                     where x.UserType == Models.User.UserTypes.Customer
                                                     select x).ToListAsync();
            return customers;
        }

        // GET: api/Users
        [HttpGet("/api/GetCustomerByPhone")]
        public async Task<ActionResult<User>> GetCustomerByPhone(string phone)
        {
            var customer = await _context.Users.Where(x => x.Phone == phone).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }
            else if (customer.UserType == Models.User.UserTypes.Customer)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
