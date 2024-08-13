using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;
using System.Net.Http;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class CreateUser : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public CreateUser(IHttpClientFactory httpClientFactory)
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
                return  Page();
            }

            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var userJson = JsonContent.Create(user);

                var result = await httpClient.PostAsync($"api/users", userJson);
            }
            return RedirectToPage("./Index");
        }
    }
}

/*using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
{
    var result = await httpClient.GetAsync($"api/users/{id}");
    var jsonString = await result.Content.ReadAsStringAsync();
    user = JsonConvert.DeserializeObject<User>(jsonString);
}*/