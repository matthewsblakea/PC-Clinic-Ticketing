using Microsoft.AspNetCore.Mvc;
using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IUserServices
    {
        Task<ActionResult<IEnumerable<User>>> GetUsers();
        Task<ActionResult<User>> GetUser(int id);
        Task<ActionResult<IEnumerable<User>>> GetTechnicians();
        Task<ActionResult<IEnumerable<User>>> GetCustomers();
        Task<ActionResult<User>> GetCustomerByPhone(string phone);
        Task<ActionResult<int>> GetCustomerIdByPhone(string phone);
        Task<IActionResult> PutUser(int id, User user);
        Task<ActionResult<User>> PostUser(User user);
        Task<ActionResult<User>> AddCustomer(User user);
        Task<ActionResult<User>> AddTechnician(User user);
        Task<IActionResult> DeleteUser(int id);
        Task<IActionResult> DeleteCustomer(int id);
        Task<IActionResult> DeleteTechnician(int id);
    }
}