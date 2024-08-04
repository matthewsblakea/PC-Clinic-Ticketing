using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface ITicketServices
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(int ticketId);
        Task CreateTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(int ticketId, Ticket ticket);
        Task DeleteTicketAsync(int ticketId);
    }
}