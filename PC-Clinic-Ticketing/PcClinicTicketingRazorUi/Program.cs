using PcClinicTicketingRazorUi.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Adding IhttpClientFactory injection

/*
 * This HttpClientFactory is used in each api call to follow the dependency inversion principle.
 * The application as a whole also follows the dependency inversion principle because razor pages is based on the MVC pattern and automates certain parts of the pattern for the developer.
 */

builder.Services.AddHttpClient(PcClinicConstants.httpClientFactoryKey, httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7224/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
