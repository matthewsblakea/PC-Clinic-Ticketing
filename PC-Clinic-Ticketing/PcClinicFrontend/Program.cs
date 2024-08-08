using PcClinicFrontend.Components;
using PcClinicApi.Models;
using PcClinicApi.PcClinicContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//
var connectionString = builder.Configuration.GetConnectionString("TicketingContext");
//

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//
builder.Services.AddDbContextFactory<TicketingContext>(options => options.UseSqlite(connectionString));
//

//
builder.Services.AddHttpClient("PcClinicApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7224/");
});
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
