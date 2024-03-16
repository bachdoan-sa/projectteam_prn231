using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Auction
{
    public class AuctionsModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<ApiModel.AuctionStateModel> AuctionStates { get; set; }
        public IActionResult OnGet()
        { 
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var task = client.GetAsync(WebAppEndpoint.AuctionState.GetOrchidAuctions);
            HttpResponseMessage result = task.Result;

            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                AuctionStates = ApiModel.AuctionStateModel.FromJson(jsonString);
                return Page();
            }
            return Page();
        }
    }
}
