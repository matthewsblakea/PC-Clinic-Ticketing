using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCClinicClassLibrary
{
    public class Ticket
    {
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
    }
}
