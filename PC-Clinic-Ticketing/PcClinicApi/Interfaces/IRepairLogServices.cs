using Microsoft.AspNetCore.Mvc;
using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IRepairLogServices
    {
        Task<ActionResult<IEnumerable<RepairLog>>> GetRepairLogs();
        Task<ActionResult<RepairLog>> GetRepairLog(int id);
        Task<ActionResult<IEnumerable<RepairLog>>> GetRepairLogsByTicketId(int ticketId);
        Task<ActionResult<IEnumerable<RepairLog>>> GetDevicesByTechnicianId(int userId);
        Task<IActionResult> PutRepairLog(int id, RepairLog repairLog);
        Task<ActionResult<RepairLog>> PostRepairLog(RepairLog repairLog);
        Task<IActionResult> DeleteRepairLog(int id);
    }
}