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
    public class TicketsController : ControllerBase
    {
        private readonly TicketingContext _context;

        public TicketsController(TicketingContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // GET: api/Tickets/GetOpenTickets
        [HttpGet("/GetOpenTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetOpenTickets()
        {
            ActionResult<IEnumerable<Ticket>> openTickets = await (from x in _context.Tickets
                                                     where x.RepairStatus != Ticket.RepairStatuses.Closed
                                                     select x).ToListAsync<Ticket>();
            return openTickets;
        }

        // GET: api/Tickets/GetClosedTickets
        [HttpGet("/GetClosedTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetClosedTickets()
        {
            ActionResult<IEnumerable<Ticket>> closedTickets = await (from x in _context.Tickets
                                                                   where x.RepairStatus == Ticket.RepairStatuses.Closed
                                                                   select x).ToListAsync<Ticket>();
            return closedTickets;
        }

        // GET: api/Tickets/GetTicketsByDeviceId
        [HttpGet("/GetTicketsByDeviceId/{deviceId}")]
        public async Task<ActionResult<List<Ticket>>> GetTicketsByDeviceId(int deviceId)
        {
            ActionResult<List<Ticket>> tickets = await _context.Tickets.Where(x => x.DeviceId == deviceId).Select(x => new Ticket
            {
                DeviceId = x.DeviceId,
                TicketId = x.TicketId,
                ReportedProblem = x.ReportedProblem,
                TechIntakeNotes = x.TechIntakeNotes,
                TicketType = x.TicketType,
                RepairStatus = x.RepairStatus,
                TicketTime = x.TicketTime,
                Device = x.Device,
                RepairLogs = x.RepairLogs
            }).ToListAsync();
            return tickets;
        }

        // GET: api/Tickets/GetTicketIdsByDeviceId
        [HttpGet("/GetTicketIdsByDeviceId/{deviceId}")]
        public async Task<ActionResult<IEnumerable<int>>> GetTicketIdsByDeviceId(int deviceId)
        {
            ActionResult<IEnumerable<int>> ticketIds = await _context.Tickets.Where(x => x.DeviceId == deviceId).Select(x => x.TicketId).ToListAsync();
            return ticketIds;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.TicketId }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
