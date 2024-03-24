using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Areas.Admin.Account
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
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
        public void OnPost()
        {
            string json = JsonConvert.SerializeObject(new
            {
                userName = Username,
                password = Password,
                email = Email,
                phone = Phone,
                address = Address,
                birthday = Birthday,
                roleId = RoleId
            });
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebAppEndpoint.Account.AddAccount, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                HttpContext.Response.Redirect("/Admin/Account/Index");
            }
            
        }
    }
}