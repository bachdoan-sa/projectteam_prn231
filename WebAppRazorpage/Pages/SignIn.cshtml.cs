using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages
{
    public class SignInModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Remove("JwToken");
        }
        public IActionResult OnPost()
        {
            string json = JsonConvert.SerializeObject(new
            {
                username = Username,
                password = Password
            });
            string token;
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var taskSignIn = client.PostAsync(WebAppEndpoint.Account.SignInAccount, content); 
            HttpResponseMessage resultSignIn = taskSignIn.Result;
            if (resultSignIn.IsSuccessStatusCode)
            {
                Task<string> readString = resultSignIn.Content.ReadAsStringAsync();
                token = readString.Result;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var taskGetRole = client.GetAsync(WebAppEndpoint.Account.GetUserRole);
                HttpResponseMessage resultRole = taskGetRole.Result;
                var roleName = resultRole.Content.ReadAsStringAsync().Result;
                HttpContext.Session.SetString("JwToken", token);
                if (roleName.ToUpper().Equals("ADMIN"))
                {
                    return Redirect("~/Admin/");
                }

                return Redirect("~/Index");
            }
            else
            {
                Task<string> readString = resultSignIn.Content.ReadAsStringAsync();
                ViewData["ErrorMessage"] = readString.Result;
                return Page();
            }
            
        }
    }
}
