namespace PcClinicClassLibrary
{
    public class Device
    {
        public enum deviceTypes
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
        public int UserId { get; set; }
        public deviceTypes DeviceType { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DevicePassword { get; set; }
        public User User { get; set; }
        public List<Ticket> Tickets { get; set; }   
    }
}
