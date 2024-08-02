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

        //Or at least make it a relative file path
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=C:\\Pc-Clinic-Db\\PcClinicDb.db;"
                );
        }

        public void AddUsers(User user)
        {
            using var context = new TicketingContext();
            context.Users.AddAsync(user);
            context.SaveChangesAsync();
        }

    }
}
