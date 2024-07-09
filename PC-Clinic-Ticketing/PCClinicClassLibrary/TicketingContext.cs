using Microsoft.EntityFrameworkCore;

namespace PCClinicClassLibrary
{
    public class TicketingContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<RepairLog> repairLogs => Set<RepairLog>();
    }
}
