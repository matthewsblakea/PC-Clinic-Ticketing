using AutoMapper;
using PcClinicApi.Interfaces;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace PcClinicApi.Services
{
    public class RepairLogServices : IRepairLogServices
    {
        private readonly TicketingContext _context;
        private readonly ILogger<RepairLogServices> _logger;
        private readonly IMapper _mapper;

        public RepairLogServices(TicketingContext context, ILogger<RepairLogServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public Task CreateRepairLogAsync(RepairLog repairLog)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRepairLogAsync(int repairLogId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RepairLog>> GetAllRepairLogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RepairLog> GetRepairLogByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRepairLogAsync(int repairLogId, RepairLog repairLog)
        {
            throw new NotImplementedException();
        }
    }
}
