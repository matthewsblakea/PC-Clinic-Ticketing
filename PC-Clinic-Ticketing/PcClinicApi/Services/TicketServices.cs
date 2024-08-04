using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcClinicApi.Interfaces;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace PcClinicApi.Services
{
    public class TicketServices : ITicketServices
    {
        private readonly TicketingContext _context;
        private readonly ILogger<TicketServices> _logger;
        private readonly IMapper _mapper;

        public TicketServices(TicketingContext context, ILogger<TicketServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTicketAsync(Ticket ticket)
        {
            var newTicket = ticket;
            _context.Tickets.Add(newTicket);
            await _context.SaveChangesAsync();
        }

        public Task DeleteTicketAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            var tickets = await _context.Tickets.ToListAsync();
            if (tickets == null)
            {
                throw new Exception(" No tickets found");
            }
            return tickets;
        }

        public Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTicketAsync(int ticketId, Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
