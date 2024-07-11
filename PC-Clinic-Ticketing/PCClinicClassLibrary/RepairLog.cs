namespace PcClinicClassLibrary
{
    public class RepairLog
    {
        public enum logType
        {
            Repair = 0,
            Contact = 1
        }

        public int RepairLogId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public logType LogType { get; set; }
        public string LogNotes { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
