using PcClinicApi.Models;

namespace PcClinicApi.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(int userId, User user);
        Task DeleteUserAsync(int userId);
    }
}