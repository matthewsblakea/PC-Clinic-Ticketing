using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;
using System.Net.Http;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class GetUserById : PageModel
    {
        public User user;

        public List<Device> devices;

        private IHttpClientFactory _httpClientFactory;

        public GetUserById(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/users/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(jsonString);
            }
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/Devices/GetDevicesByUserId/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                devices = JsonConvert.DeserializeObject<List<Device>>(jsonString);
            }
        }


    }
}
