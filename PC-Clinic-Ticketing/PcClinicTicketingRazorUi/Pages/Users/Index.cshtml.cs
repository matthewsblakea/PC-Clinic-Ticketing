using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class UsersIndex : PageModel
    {
        public List<User> users;
        
        private IHttpClientFactory _httpClientFactory;

        public UsersIndex(IHttpClientFactory httpClientFactory)
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
