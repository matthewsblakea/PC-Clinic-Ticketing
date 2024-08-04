using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IRepairLogServices
    {
        Task<IEnumerable<RepairLog>> GetAllRepairLogsAsync();
        Task<RepairLog> GetRepairLogByIdAsync(int id);
        Task CreateRepairLogAsync(RepairLog repairLog);
        Task UpdateRepairLogAsync(int repairLogId, RepairLog repairLog);
        Task DeleteRepairLogAsync(int repairLogId);
    }
}