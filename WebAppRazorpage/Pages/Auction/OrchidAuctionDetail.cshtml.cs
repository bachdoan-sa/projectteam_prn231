using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Auction
{
    [BindProperties]
    public class OrchidAuctionDetailModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        public AuctionStateModel? AuctionState { get; set; }
        public double? RisePrice { get; set; }
        public string? ReponseMessage { get; set; }
        public IActionResult OnGet(string id)
        {

            string auctionStateId = id;
            /* var accessToken = HttpContext.Session.GetString("JwToken");
             if(accessToken == null)
             {
                 
             }
             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
 */
            if (!string.IsNullOrEmpty(auctionStateId))
            {
                string url = WebAppEndpoint.AuctionState.GetOrchidAuction + '/' + auctionStateId;
                var task = client.GetAsync(url);
                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    AuctionState = AuctionStateModel.FromJsonToObject(jsonString);
                    return Page();
                }
            }
            if (AuctionState == null)
            {
                return Redirect("/Auction/Auctions");
            }
            return Page();

        }
        public IActionResult OnPostRaisePrice(string id)
        {
            var isAdmin = HttpContext.Session.GetString("IsAdJwToken");
            if (isAdmin != null && isAdmin.Equals("true"))
            {
                TempData["RaiseErrorMessage"] = "Admin không có quyền tham gia đấu giá";
                return Redirect("/Auction/OrchidAuctionDetail/" + id);
            }
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (accessToken == null)
            {
                return Redirect("/SignIn");
            }
            if (RisePrice > 0)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    dealStatus = "",
                    auctionStateId = AuctionState.Id,
                    customerId = "",
                    currency = RisePrice ?? 0
                });

                string url = WebAppEndpoint.DealHanger.RaisePrice;
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var task = client.PostAsync(url, content);

                HttpResponseMessage result = task.Result;

                if (result.IsSuccessStatusCode)
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    ReponseMessage = jsonString;
                    return Redirect("/Auction/OrchidAuctionDetail/" + id);
                }
                else
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    ReponseMessage = jsonString;
                    TempData["RaiseErrorMessage"] = readString.Result;
                    return Redirect("/Auction/OrchidAuctionDetail/" + id);
                }
            
            }
            return Redirect("/Auction/OrchidAuctionDetail/" + id);
        }
    }
}
