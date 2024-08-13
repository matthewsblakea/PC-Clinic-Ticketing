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
    public class RepairLogsController : ControllerBase
    {
        private readonly TicketingContext _context;

        public RepairLogsController(TicketingContext context)
        {
            _context = context;
        }

        // GET: api/RepairLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairLog>>> GetRepairLogs()
        {
            return await _context.RepairLogs.ToListAsync();
        }

        // GET: api/RepairLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepairLog>> GetRepairLog(int id)
        {
            var repairLog = await _context.RepairLogs.FindAsync(id);

            if (repairLog == null)
            {
                return NotFound();
            }

            return repairLog;
        }

        // GET: GetRepairLogsByTicketId/5
        [HttpGet("GetRepairLogsByTicketId/{ticketId}")]
        public async Task<ActionResult<List<RepairLog>>> GetRepairLogsByTicketId(int ticketId)
        {
            ActionResult<List<RepairLog>> repairLogs = await _context.RepairLogs.Where(x => x.TicketId == ticketId).Select(x => new RepairLog
            {
                TicketId = x.TicketId,
                UserId = x.UserId,
                RepairLogId = x.RepairLogId,
                LogType = x.LogType,
                LogTime = x.LogTime,
                LogNotes = x.LogNotes,
                User = x.User,
                Ticket = x.Ticket
            }).ToListAsync();

            return repairLogs;
        }

        // GET: GetRepairLogsByTechnicianId/5
        [HttpGet("GetRepairLogsByTechnicianId/{userId}")]
        public async Task<ActionResult<IEnumerable<RepairLog>>> GetDevicesByTechnicianId(int userId)
        {
            ActionResult<IEnumerable<RepairLog>> repairLogs = await _context.RepairLogs.Where(x => x.UserId == userId).ToListAsync();

            return repairLogs;
        }

        // PUT: api/RepairLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepairLog(int id, RepairLog repairLog)
        {
            if (id != repairLog.RepairLogId)
            {
                return BadRequest();
            }

            _context.Entry(repairLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairLogExists(id))
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

        // POST: api/RepairLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RepairLog>> PostRepairLog(RepairLog repairLog)
        {
            _context.RepairLogs.Add(repairLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepairLog", new { id = repairLog.RepairLogId }, repairLog);
        }

        // DELETE: api/RepairLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepairLog(int id)
        {
            var repairLog = await _context.RepairLogs.FindAsync(id);
            if (repairLog == null)
            {
                return NotFound();
            }

            _context.RepairLogs.Remove(repairLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairLogExists(int id)
        {
            return _context.RepairLogs.Any(e => e.RepairLogId == id);
        }
    }
}
