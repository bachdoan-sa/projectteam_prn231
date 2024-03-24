using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionState
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        public List<AuctionStateModel> AuctionStates { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _client.GetAsync(WebAppEndpoint.AuctionState.GetAllAuctionState);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                AuctionStates = JsonConvert.DeserializeObject<List<AuctionStateModel>>(jsonString);
            }
            else
            {
                // Handle error here
                // For example, redirect to an error page or display an error message
                RedirectToPage("/Error");
            }
        }
    }
}