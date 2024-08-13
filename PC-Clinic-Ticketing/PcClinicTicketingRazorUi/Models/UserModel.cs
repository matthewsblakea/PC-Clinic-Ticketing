using System.ComponentModel.DataAnnotations;

namespace PcClinicTicketingRazorUi.Models
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
        [StringLength(100)]
        public string? Password { get; set; }
        public UserTypes UserType { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string? Address { get; set; }
        [Required]
        [StringLength(100)]
        public string? City { get; set; }
        [Required]
        [StringLength(100)]
        public string? State { get; set; }
        public virtual List<Device>? Devices { get; set; }
    }
}
