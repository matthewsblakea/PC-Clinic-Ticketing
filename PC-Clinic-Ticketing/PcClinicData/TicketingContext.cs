using Microsoft.EntityFrameworkCore;
using PcClinicClassLibrary;

namespace PcClinicData
{
    public class TicketingContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<RepairLog> RepairLogs => Set<RepairLog>();
    }
}
