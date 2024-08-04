using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateRepairLogAsync(RepairLog repairLog)
        {
            var newRepairLog = repairLog;
            _context.RepairLogs.Add(newRepairLog);
            await _context.SaveChangesAsync();
        }

        public Task DeleteRepairLogAsync(int repairLogId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RepairLog>> GetAllRepairLogsAsync()
        {
            var repairLogs = await _context.RepairLogs.ToListAsync();
            if (repairLogs == null)
            {
                throw new Exception(" No repair logs found");
            }
            return repairLogs;
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
