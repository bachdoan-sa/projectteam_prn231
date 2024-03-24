using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Role
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public RoleModel Model { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                var accessToken = HttpContext.Session.GetString("JwToken");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _client.GetAsync(WebAppEndpoint.Role.GetRole + $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Model = JsonConvert.DeserializeObject<RoleModel>(jsonString);
                }
                else
                {
                    // Handle error here
                    // For example, redirect to an error page or display an error message
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
                // For example, redirect to an error page or display an error message
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var accessToken = HttpContext.Session.GetString("JwToken");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(Model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(WebAppEndpoint.Role.UpdateRole, content);

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Admin/Role/Index");
                }
                else
                {
                    // Handle error here
                    // For example, redirect to an error page or display an error message
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
                // For example, redirect to an error page or display an error message
                return RedirectToPage("/Error");
            }
        }
    }
}