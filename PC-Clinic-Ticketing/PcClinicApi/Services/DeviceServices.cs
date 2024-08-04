using AutoMapper;
using PcClinicApi.Interfaces;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace PcClinicApi.Services
{
    public class DeviceServices : IDeviceServices
    {
        private readonly TicketingContext _context;
        private readonly ILogger<DeviceServices> _logger;
        private readonly IMapper _mapper;

        public DeviceServices(TicketingContext context, ILogger<DeviceServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public Task CreateDeviceAsync(Device device)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDeviceAsync(int deviceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetDeviceByIdAsync(int deviceId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDeviceAsync(int deviceId, Device device)
        {
            throw new NotImplementedException();
        }
    }
}
