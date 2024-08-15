using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Tickets
{
    public class OpenTicketQueue : PageModel
    {
        [BindProperty]
        public List<Ticket> tickets { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public OpenTicketQueue(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            tickets = new List<Ticket>();
        }

        public async Task OnGetAsync()
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync("api/tickets/GetOpenTickets");
                var jsonString = await result.Content.ReadAsStringAsync();
                tickets = JsonConvert.DeserializeObject<List<Ticket>>(jsonString);
            }
        }
    }
}
