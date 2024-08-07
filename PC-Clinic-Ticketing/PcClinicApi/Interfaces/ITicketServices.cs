using Microsoft.AspNetCore.Mvc;
using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface ITicketServices
    {
        Task<ActionResult<IEnumerable<Ticket>>> GetTickets();
        Task<ActionResult<Ticket>> GetTicket(int id);
        Task<ActionResult<IEnumerable<Ticket>>> GetOpenTickets();
        Task<ActionResult<IEnumerable<Ticket>>> GetClosedTickets();
        Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByDeviceId(int deviceId);
        Task<ActionResult<IEnumerable<int>>> GetTicketIdsByDeviceId(int deviceId);
        Task<IActionResult> PutTicket(int id, Ticket ticket);
        Task<ActionResult<Ticket>> PostTicket(Ticket ticket);
        Task<IActionResult> DeleteTicket(int id);
    }
}