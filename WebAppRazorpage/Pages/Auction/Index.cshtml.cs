using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Auction
{
    public class IndexModel : PageModel
    {

		private readonly HttpClient client = new HttpClient();
		[BindProperty]
		public List<AuctionEventModel> ListAuction { get; set; } = new List<AuctionEventModel>();
		public void OnGet()
        {
			var task = client.GetAsync(WebApiEndpoint.AuctionEvent.GetAllAuctionEvent);
			HttpResponseMessage result = task.Result;

			if (result.IsSuccessStatusCode)
			{
				Task<string> readString = result.Content.ReadAsStringAsync();
				string jsonString = readString.Result;
				ListAuction = AuctionEventModel.FromJson(jsonString);
			}
		}
    }
}
