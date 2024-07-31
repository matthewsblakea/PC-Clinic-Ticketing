using PcClinicClassLibrary;
using PcClinicData;
using System;

namespace PcClinicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //This method to create the database is slightly cheat-y and will need to be fixed
            using (TicketingContext context = new TicketingContext())
            {
                context.Database.EnsureCreated();
            }

            //Construct sample objects

            User sampleAdmin = new User()
            {
                Password = "fakecompany1",
                UserType = User.userType.Admin,
                FirstName = "Blake",
                LastName = "Matthews",
                Phone1 = "0987654321",
                Email = "blakematthews@pcclinic.com",
                Address = "1 Fake Street",
                City = "Highland Heights",
                State = "KY"
            };

            User sampleTechnician = new User()
            {
                Password = "fakecompany2",
                UserType = User.userType.Technician,
                FirstName = "Blake",
                LastName = "Matthews",
                Phone1 = "0987654321",
                Phone2 = "0987654321",
                Email = "blakematthews@pcclinic.com",
                Address = "1 Fake Street",
                City = "Highland Heights",
                State = "KY"
            };

            User sampleCustomer = new User()
            {
                Password = "fakepassword",
                UserType = User.userType.Customer,
                FirstName = "John",
                LastName = "Smith",
                Phone1 = "1234567890",
                Email = "fakeemail@gmail.com",
                Address = "2 Fake Street",
                City = "Cincinnati",
                State = "OH"
            };

            //Populate Db with sample objects
            
            using (TicketingContext context = new TicketingContext())
            {
                context.AddUsers(sampleAdmin);
                context.AddUsers(sampleTechnician);
                context.AddUsers(sampleCustomer);
            }

                GetUsers();

            void GetUsers()
                {
                    using var context = new TicketingContext();
                    var users = context.Users.ToList();
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.FirstName + " " + user.LastName);
                    }
                }
        }
    }
}