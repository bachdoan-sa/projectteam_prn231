using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Areas.Admin.Account
{
    public class ReadModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<AccountModel> ListAccount { get; set; }
        public void OnGet()
        {
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var task = client.GetAsync(WebAppEndpoint.Account.GetAllAccount);
            HttpResponseMessage result = task.Result;
            List<AccountModel> list = new List<AccountModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                list = AccountModel.FromJson(jsonString);
            }
            ListAccount = list;
        }
    }
}
