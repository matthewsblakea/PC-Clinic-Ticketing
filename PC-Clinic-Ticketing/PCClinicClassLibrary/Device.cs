namespace PCClinicClassLibrary
{
    public class Device
    {
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
    }
}
