using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionEvent
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public DateTimeOffset BeginDateTime { get; set; }
        [BindProperty]
        public DateTimeOffset EndDateTime { get; set; }
        [BindProperty]
        public string AEStatus { get; set; }
        [BindProperty]
        public string StaffId { get; set; }
        [BindProperty]
        public string ReponseMessage { get; set; }
        public void OnPost()
        {
            string json = JsonConvert.SerializeObject(new AuctionEventModel
            {
                BeginDateTime = BeginDateTime,
                EndDateTime = EndDateTime,
                AuctionStatus = AEStatus,
                StaffId = StaffId
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebApiEndpoint.AuctionEvent.AddAuctionEvent, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ReponseMessage = readString.Result;
            }
            Redirect("~/Admin/AuctionEvent/Create");
        }
    }
}
