using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PcClinicApi.Interfaces;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace PcClinicApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly TicketingContext _context;
        private readonly ILogger<UserServices> _logger;
        private readonly IMapper _mapper;

        public UserServices(TicketingContext context, ILogger<UserServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(User user)
        {
            var newUser = user;
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }

        public Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
            {
                throw new Exception(" No users found");
            }
            return users;
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(int userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
