using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.RepairLogs
{
    public class GetRepairLogsByTicketId : PageModel
    {
        [BindProperty]
        public List<RepairLog> repairLogs { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public GetRepairLogsByTicketId(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/RepairLogs/GetRepairLogsByTicketId/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                repairLogs = JsonConvert.DeserializeObject<List<RepairLog>>(jsonString);
            }
        }
    }
}
