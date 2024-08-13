using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Tickets
{
    public class CreateTicket : PageModel
    {
        [BindProperty]
        public Ticket ticket { get; set; }

        public enum TicketTypes
        {
            Consultation = 0,
            Repair = 1,
            OnSite = 2
        }

        public enum RepairStatuses
        {
            Received = 0,
            InProgress = 1,
            Completed = 2,
            Closed = 3
        }

        [BindProperty]
        public TicketTypes TicketType { get; set; }

        [BindProperty]
        public RepairStatuses RepairStatus { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public CreateTicket(IHttpClientFactory httpClientFactory)
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
                var ticketJson = JsonContent.Create(ticket);

                var result = await httpClient.PostAsync($"api/Tickets", ticketJson);
            }
            return RedirectToPage("index");
        }
    }
}
