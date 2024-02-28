using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Role
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<RoleModel> ListRole { get; set; }
        public void OnGet()
        {
            string title = "chao mung toi thu nghiem";
            string inBrand = Request.Query["title"]; ;
            if (inBrand != null && inBrand.Length > 0)
            {
                title = inBrand;
            }
            int yearStated = 2024;
            ViewData["Title"] = title + " Established " + yearStated;
            var task = client.GetAsync(WebApiEndpoint.Role.GetAllRole);
            HttpResponseMessage result = task.Result;
            List<RoleModel> listRole = new List<RoleModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listRole = RoleModel.FromJson(jsonString);
            }
            ListRole = listRole;
        }
    }
}
