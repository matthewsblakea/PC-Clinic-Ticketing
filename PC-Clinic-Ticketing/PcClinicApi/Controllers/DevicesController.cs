using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace PcClinicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly TicketingContext _context;

        public DevicesController(TicketingContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Devices.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // GET: api/Devices
        [HttpGet("/api/GetDevicesByPhone")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByPhone(string phone)
        {
            var userId = await _context.Users.Where(x => x.Phone == phone).Select(x => x.UserId).FirstOrDefaultAsync();

            ActionResult<IEnumerable<Device>> devices = await (from x in _context.Devices
                                                           where x.UserId == userId
                                                           select x).ToListAsync();
            return devices;
        }

        // GET: api/Devices
        [HttpGet("/api/GetDevicesByUserId")]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevicesByUserId(int userId)
        {
            ActionResult<IEnumerable<Device>> devices = await _context.Devices.Where(x => x.UserId == userId).ToListAsync();

            return devices;
        }

        // GET: api/Devices
        [HttpGet("/api/GetDeviceIdsByUserId")]
        public async Task<ActionResult<IEnumerable<int>>> GetDeviceIdsByUserId(int userId)
        {
            ActionResult<IEnumerable<int>> deviceIds = await _context.Devices.Where(x => x.UserId == userId).Select(x => x.DeviceId).ToListAsync();

            return deviceIds;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }
}
