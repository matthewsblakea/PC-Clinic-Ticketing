﻿namespace PcClinicApi.Models
{
    public class Ticket
    {
        public enum RepairStatuses
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
        public RepairStatuses RepairStatus { get; set; }
        public string? Location { get; set; }
        public DateTime TicketTime { get; set; }
        public Device Device { get; set; }
        public List<RepairLog> RepairLogs { get; set; }
    }
}