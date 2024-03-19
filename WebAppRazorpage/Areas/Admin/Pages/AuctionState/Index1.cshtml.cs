using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionState
{
    public class Index1Model : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]

        public List<AuctionStateModel> AuctionState { get; set; }
        public void OnGet()
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
        }
    }
}
