using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCClinicClassLibrary
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int DeviceID { get; set; }
        public string ReportedProblem { get; set; }
        public string TechIntakeNotes { get; set; }
        public string RepairStatus { get; set; }
        public string Location { get; set; }
    }
}
