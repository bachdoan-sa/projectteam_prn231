using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.OrchidMutation
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<OrchidMutationModel> List { get; set; }
        public void OnGet()
        {
            var task = client.GetAsync(WebAppEndpoint.OrchidMutation.GetAllOrchidMutation);
            HttpResponseMessage result = task.Result;
            List<OrchidMutationModel> list = new List<OrchidMutationModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                list = OrchidMutationModel.FromJson(jsonString);
            }
            List = list;
        }
    }
}
