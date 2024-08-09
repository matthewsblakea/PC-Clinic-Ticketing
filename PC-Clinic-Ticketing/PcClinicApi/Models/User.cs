namespace PcClinicApi.Models
{
    public class User
    {
        public enum UserTypes
        {
            Customer = 0,
            Technician = 1,
            Admin = 2
        }

        public int UserId { get; set; }
        public string? Password { get; set; }
        public UserTypes UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public virtual List<Device>? Devices { get; set; }
    }
}
