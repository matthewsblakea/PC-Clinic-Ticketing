namespace PcClinicClassLibrary
{
    public class User
    {
        public User()
        {
            Devices = new List<Device>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Device> Devices { get; set; }
    }
}
