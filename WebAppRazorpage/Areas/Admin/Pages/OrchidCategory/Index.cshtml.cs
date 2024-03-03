using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.OrchidCategory
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<OrchidCategoryModel> List { get; set; }
        public void OnGet()
        {
            var task = client.GetAsync(WebApiEndpoint.OrchidCategory.GetAllOrchidCategory);
            HttpResponseMessage result = task.Result;
            List<OrchidCategoryModel> list = new List<OrchidCategoryModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                list = OrchidCategoryModel.FromJson(jsonString);
            }
            List = list;
        }
    }
}
