using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.DealHanger
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<DealHangerModel> ListDealHanger { get; set; }
        public void OnGet()
        {


            var task = client.GetAsync(WebAppEndpoint.DealHanger.GetAllDealHanger);
            HttpResponseMessage result = task.Result;
            List<DealHangerModel> listDealHanger = new List<DealHangerModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listDealHanger = DealHangerModel.FromJson(jsonString);
            }
            ListDealHanger = listDealHanger;

        }
    }
}
