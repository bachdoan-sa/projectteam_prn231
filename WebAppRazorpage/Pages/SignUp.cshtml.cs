using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Numerics;
using System.Text;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string PasswordConfirm { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Phone { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public DateTimeOffset Birthday { get; set; }
        public IActionResult OnPost()
        {
            string json = JsonConvert.SerializeObject(new
            {
                userName = Username,
                password = Password,
                passwordConfirm = PasswordConfirm,
                email = Email,
                phone = Phone,
                address = Address,
                birthday = Birthday
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebAppEndpoint.Account.SignUpAccount, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ViewData["ErrorMessage"] = "Create Account Successfully. Please login!";
                return Redirect("/SignIn");
            }
            return Page();
        }
    }
}
