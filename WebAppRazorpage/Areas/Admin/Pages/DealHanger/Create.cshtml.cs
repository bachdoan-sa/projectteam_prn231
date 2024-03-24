using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.DealHanger
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public DealHangerModel Model { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var accessToken = HttpContext.Session.GetString("JwToken");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var json = JsonConvert.SerializeObject(Model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(WebAppEndpoint.DealHanger.Post, content);

                if (response.IsSuccessStatusCode)
                {
                    var createdDealHangerId = await response.Content.ReadAsStringAsync();
                    return Redirect("/Admin/DealHanger/Index");
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