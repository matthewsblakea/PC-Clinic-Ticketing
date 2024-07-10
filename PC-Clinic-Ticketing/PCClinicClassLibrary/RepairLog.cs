﻿namespace PcClinicClassLibrary
{
    public class RepairLog
    {
        public int RepairLogId { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public enum LogType
        {
            Repair,
            Contact
        }
        public string LogNotes { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
