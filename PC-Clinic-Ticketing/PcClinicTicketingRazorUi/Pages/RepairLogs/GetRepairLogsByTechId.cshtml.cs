using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.RepairLogs
{
    public class GetRepairLogsByTechId : PageModel
    {
        [BindProperty]
        public List<RepairLog> repairLogs { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public GetRepairLogsByTechId(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/RepairLogs/GetRepairLogsByTechnicianId/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                repairLogs = JsonConvert.DeserializeObject<List<RepairLog>>(jsonString);
            }
        }
    }
}
