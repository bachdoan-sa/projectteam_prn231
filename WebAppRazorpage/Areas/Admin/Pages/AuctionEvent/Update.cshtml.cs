using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.AuctionEvent
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient _client = new HttpClient();

        [BindProperty]
        public AuctionEventModel Model { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                var response = await _client.GetAsync(WebAppEndpoint.AuctionEvent.GetAuctionEvent + $"/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Model = JsonConvert.DeserializeObject<AuctionEventModel>(jsonString);
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


                var json = JsonConvert.SerializeObject(Model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync(WebAppEndpoint.AuctionEvent.UpdateAuctionEvent, content);

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Admin/AuctionEvent/Index");
                }
                else
                {

                    // Handle error here
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