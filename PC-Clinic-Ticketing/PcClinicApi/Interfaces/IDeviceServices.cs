using Microsoft.AspNetCore.Mvc;
using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IDeviceServices
    {
        Task<ActionResult<IEnumerable<Device>>> GetDevices();
        Task<ActionResult<Device>> GetDevice(int id);
        Task<ActionResult<IEnumerable<Device>>> GetDevicesByPhone(string phone);
        Task<ActionResult<IEnumerable<Device>>> GetDevicesByUserId(int userId);
        Task<ActionResult<IEnumerable<int>>> GetDeviceIdsByUserId(int userId);
        Task<IActionResult> PutDevice(int id, Device device);
        Task<ActionResult<Device>> PostDevice(Device device);
        Task<IActionResult> DeleteDevice(int id);
    }
}