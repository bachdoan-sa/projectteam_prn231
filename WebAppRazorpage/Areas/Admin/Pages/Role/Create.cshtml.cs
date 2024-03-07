using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Role
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public string RoleName { get; set; }
        [BindProperty]
        public string ReponseMessage { get; set; }
        public void OnPost()
        {
            string json = JsonConvert.SerializeObject(new RoleModel
            {
                RoleName = RoleName
            });

            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebAppEndpoint.Role.AddRole, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ReponseMessage = readString.Result;
            }
            Redirect("~/Admin/Index");
        }
    }
}
