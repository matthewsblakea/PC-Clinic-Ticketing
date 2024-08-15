using PcClinicApi.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void DeviceBelongsToUser()
        {
            // Arrange
                        
            var testCustomer = new User()
            {
                Password = "fakecustomer1",
                UserType = User.UserTypes.Customer,
                FirstName = "John",
                LastName = "Smith",
                Phone = "1029384756",
                Email = "fakecustomer@gmail.com",
                Address = "3 Fake St",
                City = "Cincinnati",
                State = "OH"
            };

            var testDevice1 = new Device()
            {
                User = testCustomer,
                DeviceType = Device.DeviceTypes.Desktop,
                ModelNumber = "Generic desktop",
                SerialNumber = "a12345",
                DevicePassword = "desktoppassword1",
            };

            // Act

            // Assert

            Assert.AreEqual(testDevice1.User, testCustomer);
        }

        [TestMethod]
        public void TicketBelongsToDevice()
        {
            // Arrange
            var testAdmin = new User()
            {
                Password = "fakecompany1",
                UserType = User.UserTypes.Admin,
                FirstName = "Blake",
                LastName = "Matthews",
                Phone = "1234567890",
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
                Phone = "0987654321",
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
                Phone = "1029384756",
                Email = "fakecustomer@gmail.com",
                Address = "3 Fake St",
                City = "Cincinnati",
                State = "OH"
            };

            var testDevice1 = new Device()
            {
                User = testCustomer,
                DeviceType = Device.DeviceTypes.Desktop,
                ModelNumber = "Generic desktop",
                SerialNumber = "a12345",
                DevicePassword = "desktoppassword1",
            };
            var testTicket1 = new Ticket()
            {
                Device = testDevice1,
                ReportedProblem = "not able to connect to internet",
                TechIntakeNotes = "wifi adapter or driver issue. diagnose",
                TicketType = Ticket.TicketTypes.OnSite,
                RepairStatus = Ticket.RepairStatuses.Received,
                Location = "",
                TicketTime = DateTime.Now
            };

            // Act

            // Assert

            Assert.AreEqual(testTicket1.Device, testDevice1);
        }

        [TestMethod]
        public void RepairLogBelongsToTicket()
        {
            // Arrange
            var testAdmin = new User()
            {
                Password = "fakecompany1",
                UserType = User.UserTypes.Admin,
                FirstName = "Blake",
                LastName = "Matthews",
                Phone = "1234567890",
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
                Phone = "0987654321",
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
                Phone = "1029384756",
                Email = "fakecustomer@gmail.com",
                Address = "3 Fake St",
                City = "Cincinnati",
                State = "OH"
            };

            var testDevice2 = new Device()
            {
                User = testCustomer,
                DeviceType = Device.DeviceTypes.Laptop,
                ModelNumber = "Generic laptop",
                SerialNumber = "b12345",
                DevicePassword = "laptoppassword2"
            };
            var testTicket2 = new Ticket()
            {
                Device = testDevice2,
                ReportedProblem = "hard drive is old",
                TechIntakeNotes = "replace HDD with SSD and transfer customer data",
                TicketType = Ticket.TicketTypes.Repair,
                RepairStatus = Ticket.RepairStatuses.InProgress,
                Location = "",
                TicketTime = DateTime.Now
            };
            var testRepairLog21 = new RepairLog()
            {
                Ticket = testTicket2,
                User = testTech,
                LogType = RepairLog.LogTypes.Contact,
                LogTime = DateTime.Now,
                LogNotes = "informed customer of ssd recommendation and received consent to purchase and install device",
            };

            // Act

            // Assert

            Assert.AreEqual(testRepairLog21.Ticket, testTicket2);
        }
    }
}