using System.ComponentModel.DataAnnotations;

namespace PcClinicTicketingRazorUi.Models
{
    public class RepairLog
    {
        public enum LogTypes
        {
            Repair = 0,
            Contact = 1
        }

        public int RepairLogId { get; set; }
        public int? TicketId { get; set; }
        public int? UserId { get; set; }
        public LogTypes LogType { get; set; }
        public DateTime LogTime { get; set; }
        [Required]
        public string LogNotes { get; set; }
        public virtual User? User { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
