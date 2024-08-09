namespace PcClinicApi.Models
{
    public class Ticket
    {
        public enum TicketTypes
        {
            Consultation = 0,
            Repair = 1,
            OnSite = 2
        }
        
        public enum RepairStatuses
        {
            Received = 0,
            InProgress = 1,
            Completed = 2,
            Closed = 3
        }

        public int TicketId { get; set; }
        public int? DeviceId { get; set; }
        public string ReportedProblem { get; set; }
        public string TechIntakeNotes { get; set; }
        public TicketTypes TicketType { get; set; }
        public RepairStatuses RepairStatus { get; set; }
        public string? Location { get; set; }
        public DateTime TicketTime { get; set; }
        public virtual Device? Device { get; set; }
        public virtual List<RepairLog>? RepairLogs { get; set; }
    }
}
