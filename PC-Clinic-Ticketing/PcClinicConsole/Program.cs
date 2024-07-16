using PcClinicData;
using System;

namespace PcClinicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //This method to create the database is slightly cheat-y and will need to be fixed

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