using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Customer
{
    public class CustomerWalletModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public double Balance { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string json = JsonConvert.SerializeObject(new WalletModel
            {
                Balance = Balance
            });

            var accessToken = HttpContext.Session.GetString("JwToken");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(WebAppEndpoint.Wallet.UpdateWallet, content);

            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Customer/ProfileCustomer");
            }
            else
            {
                // Handle error here
                return Page();
            }
        }
    }
}

