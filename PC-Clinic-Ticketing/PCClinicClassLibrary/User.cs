namespace PcClinicClassLibrary
{
    public class User
    {
        public User()
        {
            Devices = new List<Device>();
            RepairLogs = new List<RepairLog>();
        }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Device> Devices { get; set; }
        public List<RepairLog> RepairLogs { get; set; }
    }
}
