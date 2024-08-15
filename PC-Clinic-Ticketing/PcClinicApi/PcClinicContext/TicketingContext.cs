using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PcClinicApi.Models;

namespace PcClinicApi.PcClinicContext
{
    /*
     * Creating a separate class for the DbContext instead of placing it in program.cs or some other silly place
     * like most microsoft example documentation does follows the single-responsibility principle.
     * To follow the single-responsibility principle even further, the connection string for the sqlite database
     * is kept in a separate class and only referenced here.
     */
    
    public class TicketingContext : DbContext
    {
        
        private readonly DbSettings _dbSettings = new();
        
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RepairLog> RepairLogs { get; set; }

        // Configuring the database provider and connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_dbSettings.ConnectionString);
        }

        // Configuring the model for the entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(x => x.UserId);
            modelBuilder.Entity<Device>()
                .ToTable("Devices")
                .HasKey(x => x.DeviceId);
            modelBuilder.Entity<Ticket>()
                .ToTable("Tickets")
                .HasKey(x => x.TicketId);
            modelBuilder.Entity<RepairLog>()
                .ToTable("RepairLogs")
                .HasKey(x => x.RepairLogId);
        }
    }
}
