using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.OrchidCategory
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public string CategoryName { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Id = id;
            var response = await _client.GetAsync(WebAppEndpoint.OrchidCategory.GetOrchidCategory + $"/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var orchidCategory = JsonConvert.DeserializeObject<OrchidCategoryModel>(jsonString);
                CategoryName = orchidCategory.CategoryName;
                return Page();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var json = JsonConvert.SerializeObject(new
                {
                    id = Id,
                    categoryName = CategoryName
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(WebAppEndpoint.OrchidCategory.UpdateOrchidCategory, content);

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Admin/OrchidCategory/Index");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}