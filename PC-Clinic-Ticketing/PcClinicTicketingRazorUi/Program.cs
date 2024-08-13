using PcClinicTicketingRazorUi.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Adding IhttpClientFactory injection
/*string? httpClientName = builder.Configuration["PcClinicApi"];
ArgumentException.ThrowIfNullOrEmpty(httpClientName);

builder.Services.AddHttpClient(
    httpClientName, client =>
    {
        client.BaseAddress = new Uri("https://localhost:7224/");

        client.DefaultRequestHeaders.UserAgent.ParseAdd("requestHeader");
    });*/

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
