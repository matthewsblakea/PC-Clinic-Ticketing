using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class Index : PageModel
    {
        [BindProperty]
        public List<User> users { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public Index(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            users = new List<User>();
        }

        public async Task OnGetAsync()
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                    var result = await httpClient.GetAsync("api/users");
                    var jsonString = await result.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            }
        }
    }
}
