using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Orchid
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<OrchidModel> ListOrchid { get; set; }
        public void OnGet()
        {
            var task = client.GetAsync(WebApiEndpoint.Orchid.GetAllOrchid);
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
