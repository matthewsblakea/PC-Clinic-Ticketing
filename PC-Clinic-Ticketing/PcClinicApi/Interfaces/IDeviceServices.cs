using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IDeviceServices
    {
        Task<IEnumerable<Device>> GetAllDevicesAsync();
        Task<Device> GetDeviceByIdAsync(int deviceId);
        Task CreateDeviceAsync(Device device);
        Task UpdateDeviceAsync(int deviceId, Device device);
        Task DeleteDeviceAsync(int deviceId);
    }
}