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

        //IMPORTANT need to take the connection string out later. Should NOT be hard-coded. This is just to get it started.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=D:\\DOCS\\CodeKY\\Projects\\PC-Clinic-Ticketing\\Pc-Clinic-Ticketing\\PcClinicDb\\PcClinicDb.db;"
                );
        }
    }
}
