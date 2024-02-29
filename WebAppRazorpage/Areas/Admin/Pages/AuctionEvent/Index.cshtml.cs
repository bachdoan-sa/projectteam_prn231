using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionEvent
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<AuctionEventModel> ListAuctionEvent { get; set; }
        public void OnGet()
        {

            var task = client.GetAsync(WebApiEndpoint.AuctionEvent.GetAllAuctionEvent);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                ListAuctionEvent = AuctionEventModel.FromJson(jsonString);
            }
        }
    }
}
