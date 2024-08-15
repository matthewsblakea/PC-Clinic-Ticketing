using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Tickets
{
    public class EditTicket : PageModel
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

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public EditTicket(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/Tickets/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                ticket = JsonConvert.DeserializeObject<Ticket>(jsonString);
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
                var ticketJson = JsonContent.Create(ticket);

                var result = await httpClient.PutAsync($"api/Tickets/{ticket.TicketId}", ticketJson);
            }
            return RedirectToPage("/Tickets/OpenTicketQueue");
        }
    }
}
