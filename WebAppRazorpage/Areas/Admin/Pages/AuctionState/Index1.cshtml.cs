using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionState
{
    public class Index1Model : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public string ChangeItemId { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        [BindProperty]
        public List<AuctionStateModel> AuctionState { get; set; }
        public IActionResult OnGet()
        {
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var task = client.GetAsync(WebAppEndpoint.AuctionState.GetAuctionStateByStatusPending);
            HttpResponseMessage result = task.Result;
            List<AuctionStateModel> list = new List<AuctionStateModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                list = AuctionStateModel.FromJson(jsonString);
            }
            AuctionState = list;

            if (!string.IsNullOrEmpty(SuccessMessage))
            {
                TempData["SuccessMessage"] = SuccessMessage;
            }
            return Page();
        }

        

        public IActionResult OnPostChangeStatus()
        {
            string json = JsonConvert.SerializeObject(new
            {

            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PutAsync($"https://localhost:7253/api/AuctionState/ChangeAuctionStatus/{ChangeItemId}", content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                SuccessMessage = "Auction status changed successfully";
            }
            return RedirectToPage();
        }
    }
}
