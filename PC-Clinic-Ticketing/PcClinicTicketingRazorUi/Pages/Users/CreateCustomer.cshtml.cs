using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PcClinicTicketingRazorUi.Constants;
using PcClinicTicketingRazorUi.Models;
using System.Net.Http;

namespace PcClinicTicketingRazorUi.Pages.Users
{
    public class CreateCustomer : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        /* This HttpClientFactory is used in each api call to follow the dependency inversion principle. */
        private IHttpClientFactory _httpClientFactory;

        public CreateCustomer(IHttpClientFactory httpClientFactory)
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
                user.UserType = Models.User.UserTypes.Customer;
                var userJson = JsonContent.Create(user);

                var result = await httpClient.PostAsync($"api/users", userJson);
            }
            return RedirectToPage("index");
        }
    }
}