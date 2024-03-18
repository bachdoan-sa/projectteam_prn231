using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Auction
{
    public class AuctionsModel : PageModel
    {

        private readonly HttpClient client = new HttpClient();
        public TimeSpan TimeRemaining { get; private set; }

        [BindProperty]
        public List<AuctionStateModel> ListStateAuction { get; set; } = new List<AuctionStateModel>();
        public void OnGet()
        {
            var task = client.GetAsync(WebAppEndpoint.AuctionState.GetAllAuctionState);
            HttpResponseMessage result = task.Result;

            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                ListStateAuction = AuctionStateModel.FromJson(jsonString);

            }
        }

    }
}
