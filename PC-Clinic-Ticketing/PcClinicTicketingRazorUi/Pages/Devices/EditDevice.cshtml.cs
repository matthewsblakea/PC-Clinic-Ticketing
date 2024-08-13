using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Devices
{
    public class EditDevice : PageModel
    {
        [BindProperty]
        public Device device { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public EditDevice(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/devices/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                device = JsonConvert.DeserializeObject<Device>(jsonString);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var deviceJson = JsonContent.Create(device);

                var result = await httpClient.PutAsync($"api/devices/{device.DeviceId}", deviceJson);
            }
            return RedirectToPage("index");
        }
    }
}
