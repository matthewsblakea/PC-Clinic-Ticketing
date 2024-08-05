using Microsoft.AspNetCore.Mvc;
using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface ITicketServices
    {
        Task<ActionResult<IEnumerable<Ticket>>> GetTickets();
        Task<ActionResult<Ticket>> GetTicket(int id);
        Task<IActionResult> PutTicket(int id, Ticket ticket);
        Task<ActionResult<Ticket>> PostTicket(Ticket ticket);
        Task<IActionResult> DeleteTicket(int id);
    }
}