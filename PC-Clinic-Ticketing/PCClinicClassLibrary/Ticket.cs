namespace PcClinicClassLibrary
{
    public class Ticket
    {
        public Ticket()
        {
            RepairLogs = new List<RepairLog>();
        }
        public int TicketId { get; set; }
        public int DeviceId { get; set; }
        public string ReportedProblem { get; set; }
        public string TechIntakeNotes { get; set; }
        public enum RepairStatus
        {
            Submitted,
            Received,
            InProgress,
            Completed,
            Closed
        }
        public string Location { get; set; }
        public Device Device { get; set; }
        public List<RepairLog> RepairLogs { get; set; }
    }
}
