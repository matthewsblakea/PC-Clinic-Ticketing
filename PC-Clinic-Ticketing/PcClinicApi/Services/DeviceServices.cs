using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateDeviceAsync(Device device)
        {
            var newDevice = device;
            _context.Devices.Add(newDevice);
            await _context.SaveChangesAsync();
        }

        public Task DeleteDeviceAsync(int deviceId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Device>> GetAllDevicesAsync()
        {
            var devices = await _context.Devices.ToListAsync();
            if (devices == null)
            {
                throw new Exception(" No devices found");
            }
            return devices;
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
