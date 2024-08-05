using Microsoft.AspNetCore.Mvc;
using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IUserServices
    {
        Task<ActionResult<IEnumerable<User>>> GetUsers();
        Task<ActionResult<User>> GetUser(int id);
        Task<IActionResult> PutUser(int id, User user);
        Task<ActionResult<User>> PostUser(User user);
        Task<IActionResult> DeleteUser(int id);
    }
}