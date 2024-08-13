using System.ComponentModel.DataAnnotations;

namespace PcClinicTicketingRazorUi.Models
{
    public class Device
    {
        public enum DeviceTypes
        {
            Desktop = 0,
            AIO = 1,
            Laptop = 2,
            Tablet = 3,
            Phone = 4,
            Watch = 5,
            NetworkingDevice = 6,
            Printer = 7,
            Other = 8
        }

        public int DeviceId { get; set; }
        public int? UserId { get; set; }
        public DeviceTypes DeviceType { get; set; }
        [Required]
        [StringLength(100)]
        public string ModelNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string SerialNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string DevicePassword { get; set; }
        public virtual User? User { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }
    }
}
