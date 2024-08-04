using AutoMapper;
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

        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
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
