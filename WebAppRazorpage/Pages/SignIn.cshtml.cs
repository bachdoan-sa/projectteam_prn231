using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
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
        [BindProperty]
        public string ReponseMessage { get; set; }
        public void OnPost()
        {
            string json = JsonConvert.SerializeObject(new
            {
                username = Username,
                password = Password
            });
            string token;
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebAppEndpoint.Account.SignInAccount, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                token = readString.Result;
                HttpContext.Session.SetString("JwToken", token);
            }
            else
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ReponseMessage = readString.Result;
            }
            
        }
    }
}
