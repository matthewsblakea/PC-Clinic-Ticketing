using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Devices
{
    public class CreateDevice : PageModel
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

        public CreateDevice(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGetAsync()
        {

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

                var result = await httpClient.PostAsync($"api/Devices", deviceJson);
            }
            return RedirectToPage("index");
        }
    }
}
