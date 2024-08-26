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

        public enum DeviceTypes
        {
            Desktop = 0,
            AIO = 1,
            Laptop = 2,
            Tablet = 3,
            Phone = 4,
            Watch = 5,
            NetworkingDevice = 6,
            Printer = 7,
            Other = 8
        }

        [BindProperty]
        public DeviceTypes DeviceType { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public EditDevice(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/Devices/{id}");
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

                var result = await httpClient.PutAsync($"api/Devices/{device.DeviceId}", deviceJson);
            }
            return RedirectToPage("/Devices/GetDevicesByUserId", new { id = device.UserId});
        }
    }
}
