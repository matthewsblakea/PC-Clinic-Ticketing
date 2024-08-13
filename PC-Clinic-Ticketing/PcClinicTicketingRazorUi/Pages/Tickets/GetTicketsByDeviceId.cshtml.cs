using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;
using System.Net.Http;

namespace PcClinicTicketingRazorUi.Pages.Tickets
{
    public class GetTicketsByDeviceId : PageModel
    {
        [BindProperty]
        public List<Ticket> tickets { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public GetTicketsByDeviceId(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/Tickets/GetTicketsByDeviceId/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                tickets = JsonConvert.DeserializeObject<List<Ticket>>(jsonString);
            }
        }
    }
}
