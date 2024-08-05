using PcClinicApi.PcClinicContext;
using Microsoft.EntityFrameworkCore;
using PcClinicApi.Models;
using PcClinicApi.Controllers;
using PcClinicApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TicketingContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cheaty database creation
using (TicketingContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
/*}

using (TicketingContext _context = new())
{*/
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

    context.Add(testAdmin);
    context.Add(testTech);
    context.Add(testCustomer);

    context.SaveChanges();
    /*var users = _context.Users.ToList();
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
    }*/

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