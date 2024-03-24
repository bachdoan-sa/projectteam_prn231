using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Areas.Admin.Account
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public DateTimeOffset Birthday { get; set; }
        [BindProperty]
        public string RoleId { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
          
            var response = await _client.GetAsync(WebAppEndpoint.Account.GetAccount + $"/{id}");

            if (response.IsSuccessStatusCode)
            {
                var accountJson = await response.Content.ReadAsStringAsync();
                var account = JsonConvert.DeserializeObject<AccountModel>(accountJson);
                Id = account.Id;
                Username = account.UserName;
                Email = account.Email;
                Phone = account.Phone;
                Address = account.Address;
                Birthday = (DateTimeOffset)account.Birthdate;
                RoleId = account.RoleId;

                return Page();
            }
            else
            {
                // Handle error here
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string json = JsonConvert.SerializeObject(new
            {
                id = Id,
                userName = Username,
                password = Password,
                email = Email,
                phone = Phone,
                address = Address,
                birthday = Birthday,
                roleId = RoleId
            });

            var accessToken = HttpContext.Session.GetString("JwToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(WebAppEndpoint.Account.UpdateAccount, content);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Account/Index");
            }
            else
            {
                // Handle error here
                return Page();
            }
        }
    }
}