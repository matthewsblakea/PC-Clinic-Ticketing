using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCClinicClassLibrary
{
    public class RepairLog
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public enum LogType
        {
            Repair,
            Contact
        }
        public string LogNotes { get; set; }
    }
}
