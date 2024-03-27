using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;

namespace WebAppRazorpage.Pages.Customer
{
    public class AuctionHistoryModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();


        public List<DealHangerModel> ListDealhanger { get; set; }

        public void OnGet()
        {
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var task = client.GetAsync($"https://localhost:7253/api/DealHanger/Customer");
            HttpResponseMessage result = task.Result;
            List<DealHangerModel> listDealhanger = new List<DealHangerModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listDealhanger = DealHangerModel.FromJson(jsonString);
            }
            ListDealhanger = listDealhanger;
        }
    }
}