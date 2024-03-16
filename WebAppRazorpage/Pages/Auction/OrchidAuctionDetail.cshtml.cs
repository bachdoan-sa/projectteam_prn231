using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Auction
{
    [BindProperties]
    public class OrchidAuctionDetailModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        public AuctionStateModel AuctionState { get; set; }
        public IActionResult OnGet()
        {

            string auctionStateId = ViewData["AuctionStateId"] as string ?? "";
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (!string.IsNullOrEmpty(auctionStateId))
            {
                string url = WebAppEndpoint.AuctionState.GetOrchidAuction + '/' + auctionStateId;
                var task = client.GetAsync(url);
                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    AuctionState = AuctionStateModel.FromJson(jsonString).FirstOrDefault() ?? new AuctionStateModel();
                    return Page();
                }
            }

            return Page();

        }
    }
}
