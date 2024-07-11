namespace PcClinicClassLibrary
{
    public class Ticket
    {
        public Ticket()
        {
            RepairLogs = new List<RepairLog>();
        }
        public enum repairStatus
        {
            Submitted = 0,
            Received = 1,
            InProgress = 2,
            Completed = 3,
            Closed = 4
        }

        public int TicketId { get; set; }
        public int DeviceId { get; set; }
        public string ReportedProblem { get; set; }
        public string TechIntakeNotes { get; set; }
        public repairStatus RepairStatus { get; set; }
        public string Location { get; set; }
        public Device Device { get; set; }
        public List<RepairLog> RepairLogs { get; set; }
    }
}
