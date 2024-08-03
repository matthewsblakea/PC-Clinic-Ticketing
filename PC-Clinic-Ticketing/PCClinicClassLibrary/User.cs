namespace PcClinicClassLibrary
{
    public class User
    {
        public enum userType
        {
            Customer = 0,
            Technician = 1,
            Admin = 2
        }

        public int UserId { get; set; }
        public string Password { get; set; }
        public userType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<Device> Devices { get; set; }
    }
}