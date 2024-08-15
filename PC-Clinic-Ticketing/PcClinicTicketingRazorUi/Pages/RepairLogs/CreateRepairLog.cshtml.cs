using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.RepairLogs
{
    public class CreateRepairLog : PageModel
    {
        [BindProperty]
        public RepairLog repairLog { get; set; }

        public enum LogTypes
        {
            Repair = 0,
            Contact = 1
        }

        [BindProperty]
        public LogTypes LogType { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public CreateRepairLog(IHttpClientFactory httpClientFactory)
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
                var repairLogJson = JsonContent.Create(repairLog);

                var result = await httpClient.PostAsync($"api/RepairLogs", repairLogJson);
            }
            return RedirectToPage("/Tickets/OpenTicketQueue");
        }
    }
}
