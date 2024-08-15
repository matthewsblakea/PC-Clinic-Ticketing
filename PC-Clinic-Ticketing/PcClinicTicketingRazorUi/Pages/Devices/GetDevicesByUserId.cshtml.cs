using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Devices
{
    public class GetDevicesByUserId : PageModel
    {
        [BindProperty]
        public List<Device> devices { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public GetDevicesByUserId(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/Devices/GetDevicesByUserId/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                devices = JsonConvert.DeserializeObject<List<Device>>(jsonString);
            }
        }
    }
}
