using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionState
{
    public class ListAuctionEndsModel : PageModel
    {
        
        private readonly HttpClient client = new HttpClient();

        [BindProperty]
        public List<AuctionStateModel> AuctionStates { get; set; }
        [BindProperty]
        public string auctionStateId { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var response = await client.GetAsync(WebAppEndpoint.AuctionState.GetAuctionStateEnds);
            List<AuctionStateModel> list = new List<AuctionStateModel>();
            if (response.IsSuccessStatusCode)
            {
                Task<string> readString = response.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                list = AuctionStateModel.FromJson(jsonString);
                AuctionStates = list;
            }
            else
            {
                AuctionStates = new List<AuctionStateModel>();
            }
            if (!string.IsNullOrEmpty(SuccessMessage))
            {
                TempData["SuccessMessage"] = SuccessMessage;
            }
            return Page();
        }

        public IActionResult OnPostEndAuction()
        {
            string json = JsonConvert.SerializeObject(new
            {

            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync($"https://localhost:7253/api/AuctionState/EndAuction/{auctionStateId}", content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                SuccessMessage = "End auction ,create order successfully";
            }
            else
            {
                SuccessMessage = "Error !!!!";
            }
            return RedirectToPage();
        }
    }
}
