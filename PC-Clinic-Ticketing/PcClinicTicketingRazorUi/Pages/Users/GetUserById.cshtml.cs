using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;
using System.Net.Http;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class GetUserById : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public GetUserById(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGetAsync(int id)
        {
            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var result = await httpClient.GetAsync($"api/users/{id}");
                var jsonString = await result.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(jsonString);
            }
        }
    }
}
