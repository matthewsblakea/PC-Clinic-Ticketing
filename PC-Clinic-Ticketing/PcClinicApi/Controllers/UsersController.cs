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

        // GET: api/Users/GetTechnicians
        [HttpGet("/GetTechnicians")]
        public async Task<ActionResult<IEnumerable<User>>> GetTechnicians()
        {
            ActionResult<IEnumerable<User>> techs = await (from x in _context.Users
                                       where x.UserType == Models.User.UserTypes.Technician
                                       select x).ToListAsync();
            return techs;
        }

        // GET: api/Users/GetCustomers
        [HttpGet("/GetCustomers")]
        public async Task<ActionResult<IEnumerable<User>>> GetCustomers()
        {
            ActionResult<IEnumerable<User>> customers = await (from x in _context.Users
                                                               where x.UserType == Models.User.UserTypes.Customer
                                                               select x).ToListAsync();
            return customers;
        }

        // GET: api/Users/GetCustomerByPhone
        [HttpGet("/GetCustomerByPhone/{phone}")]
        public async Task<ActionResult<User>> GetCustomerByPhone(string phone)
        {
            var customer = await _context.Users.Where(x => x.UserType == Models.User.UserTypes.Customer).
                Where(x => x.Phone == phone).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return customer;
            }
        }

        // GET: api/Users/GetCustomerIdByPhone
        [HttpGet("/GetCustomerIdByPhone/{phone}")]
        public async Task<ActionResult<int>> GetCustomerIdByPhone(string phone)
        {
            var customer = await _context.Users.Where(x => x.Phone == phone).FirstOrDefaultAsync();

            if (customer == null)
            {
                return NotFound();
            }
            else if (customer.UserType == Models.User.UserTypes.Customer)
            {
                var customerId = customer.UserId;
                return customerId;
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

        // POST: api/Users/AddCustomer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddCustomer")]
        public async Task<ActionResult<User>> AddCustomer(User user)
        {
            _context.Users.Add(user);
            user.UserType = Models.User.UserTypes.Customer;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // POST: api/Users/AddTechnician
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddTechnician")]
        public async Task<ActionResult<User>> AddTechnician(User user)
        {
            _context.Users.Add(user);
            user.UserType = Models.User.UserTypes.Technician;
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

        // DELETE: api/Users/DeleteCustomer/5
        [HttpDelete("/DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.UserType != Models.User.UserTypes.Customer)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/DeleteTechnician/5
        [HttpDelete("/DeleteTechnician/{id}")]
        public async Task<IActionResult> DeleteTechnician(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.UserType != Models.User.UserTypes.Technician)
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
