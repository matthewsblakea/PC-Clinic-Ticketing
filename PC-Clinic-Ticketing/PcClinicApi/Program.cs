using PcClinicApi.PcClinicContext;
using Microsoft.EntityFrameworkCore;
using PcClinicApi.Models;
using PcClinicApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TicketingContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cheaty database creation and objects created to test api alls and populate the database with sample data.
using (TicketingContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

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
    context.Add(testAdmin);
    context.Add(testTech);
    context.Add(testCustomer);

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
    
    context.Add(testDevice1);
    context.Add(testTicket1);

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
    context.Add(testDevice2);
    context.Add(testTicket2);
    context.Add(testRepairLog21);

    var testDevice3 = new Device()
    {
        User = testCustomer,
        DeviceType = Device.DeviceTypes.Phone,
        ModelNumber = "Generic iphone",
        SerialNumber = "c12345",
        DevicePassword = "iphonepassword3"
    };
    var testTicket3 = new Ticket()
    {
        Device = testDevice3,
        ReportedProblem = "broken screen",
        TechIntakeNotes = "order iphone 14 screen and replace the broken component",
        TicketType = Ticket.TicketTypes.Repair,
        RepairStatus = Ticket.RepairStatuses.Completed,
        Location = "",
        TicketTime = DateTime.Now
    };
    var testRepairLog31 = new RepairLog()
    {
        Ticket = testTicket3,
        User = testAdmin,
        LogType = RepairLog.LogTypes.Repair,
        LogTime = DateTime.Now,
        LogNotes = "replaced broken display component with new one"
    };
    var testRepairLog32 = new RepairLog()
    {
        Ticket = testTicket3,
        User = testTech,
        LogType = RepairLog.LogTypes.Contact,
        LogTime = DateTime.Now,
        LogNotes = "contacted customer that repair is complete and they can pick up their phone"
    };
    context.Add(testDevice3);
    context.Add(testTicket3);
    context.Add(testRepairLog31);
    context.Add(testRepairLog32);

    var testDevice4 = new Device()
    {
        User = testCustomer,
        DeviceType = Device.DeviceTypes.Phone,
        ModelNumber = "Generic samsung galaxy",
        SerialNumber = "d12345",
        DevicePassword = "samsungpassword4"
    };
    var testTicket4 = new Ticket()
    {
        Device = testDevice4,
        ReportedProblem = "questions about applications",
        TechIntakeNotes = "answered customer questions about applications",
        TicketType = Ticket.TicketTypes.Consultation,
        RepairStatus = Ticket.RepairStatuses.Closed,
        Location = "",
        TicketTime = DateTime.Now
    };
    
    context.Add(testDevice4);
    context.Add(testTicket4);

    context.SaveChanges();
    

}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();