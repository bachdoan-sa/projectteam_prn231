using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.ProductOwner
{
    public class CreateAuctionEventModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public double? StartingPrice { get; set; }

        [BindProperty]
        public double? ExpectedPrice { get; set; }

        [BindProperty]
        public double? MinRaise { get; set; }

        [BindProperty]
        public double? MaxRaise { get; set; }

        [BindProperty]
        public DateTimeOffset BeginDateTime { get; set; }

        [BindProperty]
        public DateTimeOffset EndDateTime { get; set; }
        [BindProperty]
        public string ReponseMessage { get; set; }
        public IActionResult OnPost(string id)
        {
            string json = JsonConvert.SerializeObject(new
            {
                orchidId = id ,
                BeginDateTime = BeginDateTime,
                EndDateTime = EndDateTime,
                StartingPrice = StartingPrice,
                ExpectedPrice = ExpectedPrice,
                MinRaise = MinRaise,
                MaxRaise = MaxRaise

            }); ;

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebAppEndpoint.AuctionState.CreateAuctionByOwner, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ReponseMessage = readString.Result;
            }
            return Redirect("~/ProductOwner/Profile");
        }
    }
}
