using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Customer
{
    public class ProfileCustomerModel : PageModel
    {

    private readonly HttpClient _client = new HttpClient();
        [BindProperty]

        public AccountModel? Customer { get; set; }


        public IActionResult OnGet(int customerId)
        {
            //var accessToken = HttpContext.Session.GetString("JwToken");
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage result = _client.GetAsync($"https://localhost:7253/api/Account/get-single/{customerId}").Result;
        
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString=  readString .Result;
                Customer = AccountModel.FromJson(jsonString).FirstOrDefault();
            }
            if(Customer == null)
            {
                return Redirect("/SignIn");
            }
            return Page();
        
        }
    }
}
