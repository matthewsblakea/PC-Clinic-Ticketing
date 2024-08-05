using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;

namespace ConsoleTestApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            using (TicketingContext _context = new())
            {
                //_context.Database.EnsureDeleted();
                //_context.Database.EnsureCreated();

                var testAdmin = new User()
                {
                    Password = "fakecompany1",
                    UserType = User.UserTypes.Admin,
                    FirstName = "Blake",
                    LastName = "Matthews",
                    Phone1 = "1234567890",
                    Phone2 = "",
                    Email = "admin@pcclinic.com",
                    Address = "1 Fake St",
                    City = "Highland Heights",
                    State = "KY"
                };
                var testTech = new User()
                {
                    Password = "fakecompany2",
                    UserType = User.UserTypes.Technician,
                    FirstName = "Matthew",
                    LastName = "Blake",
                    Phone1 = "0987654321",
                    Phone2 = "",
                    Email = "technician1@pcclinic.com",
                    Address = "2 Fake St",
                    City = "Cold Spring",
                    State = "KY"
                };
                var testCustomer = new User()
                {
                    Password = "fakecustomer1",
                    UserType = User.UserTypes.Customer,
                    FirstName = "John",
                    LastName = "Smith",
                    Phone1 = "1029384756",
                    Phone2 = "",
                    Email = "fakecustomer@gmail.com",
                    Address = "3 Fake St",
                    City = "Cincinnati",
                    State = "OH"
                };

                _context.Add(testAdmin);
                _context.Add(testTech);
                _context.Add(testCustomer);

                _context.SaveChanges();
                var users = _context.Users.ToList();
                foreach (User user in users)
                {
                    Console.WriteLine(user.Password);
                    Console.WriteLine(user.UserType);
                    Console.WriteLine(user.FirstName);
                    Console.WriteLine(user.LastName);
                    Console.WriteLine(user.Phone1);
                    Console.WriteLine(user.Phone2);
                    Console.WriteLine(user.Email);
                    Console.WriteLine(user.Address);
                    Console.WriteLine(user.City);
                    Console.WriteLine(user.State);
                }

            }
        }
    }
}