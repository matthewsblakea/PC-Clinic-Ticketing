namespace PcClinicClassLibrary
{
    public class Device
    {
        public Device()
        {
            Tickets = new List<Ticket>();
        }
        public int DeviceId { get; set; }
        public int UserId { get; set; }
        public enum DeviceType
        {
            Desktop,
            AIO,
            Laptop,
            Tablet,
            Phone,
            Watch,
            NetworkingDevice,
            Printer,
            Other            
        }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DevicePassword { get; set; }
        public User User { get; set; }
        public List<Ticket> Tickets { get; set; }   
    }
}
