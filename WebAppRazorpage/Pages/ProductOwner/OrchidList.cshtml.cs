using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.ProductOwner
{
    public class OrchidListModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<OrchidModel> ListOrchid { get; set; }
        public void OnGet()
        {
            string ownerId = "1";
            var task = client.GetAsync("https://localhost:7253/api/Orchids/Owner/e08249799f7b4798ad18f91a7a1117ed");
            HttpResponseMessage result = task.Result;
            List<OrchidModel> listOrchid = new List<OrchidModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listOrchid = OrchidModel.FromJson(jsonString);
            }
            ListOrchid = listOrchid;
        }
    }
}
