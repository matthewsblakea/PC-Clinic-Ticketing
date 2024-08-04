using AutoMapper;
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

        public Task CreateTicketAsync(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTicketAsync(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            throw new NotImplementedException();
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
