using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PcClinicApi.Models;

namespace PcClinicApi.PcClinicContext
{
    public class TicketingContext : DbContext
    {
        // DbSettings field to store the connection string
        private readonly DbSettings _dbSettings;
        // Constructor to inject the DbSettings model
        public TicketingContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        //DbSet properties for models
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RepairLog> RepairLogs { get; set; }

        // Configuring the database provider and connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_dbSettings.ConnectionString);
        }

        // Configuring the model for the Todo entity
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
