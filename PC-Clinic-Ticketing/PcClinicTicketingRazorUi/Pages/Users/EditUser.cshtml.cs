using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class EditUser : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        private IHttpClientFactory _httpClientFactory;

        public EditUser(IHttpClientFactory httpClientFactory)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var httpClient = _httpClientFactory.CreateClient(PcClinicConstants.httpClientFactoryKey))
            {
                var userJson = JsonContent.Create(user);

                var result = await httpClient.PutAsync($"api/users/{user.UserId}", userJson);
            }
            return RedirectToPage("./Index");
        }


    }
}
