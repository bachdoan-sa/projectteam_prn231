using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Mutation
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<MutationModel> ListMutation { get; set; }
        private readonly INotyfService _notyf;

        public IndexModel(INotyfService notyf)
        {
            _notyf = notyf;
        }
        public void OnGet()
        {
           
            var task = client.GetAsync(WebAppEndpoint.Mutation.GetAllMutation);
            HttpResponseMessage result = task.Result;
            List<MutationModel> listMutation = new List<MutationModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listMutation = MutationModel.FromJson(jsonString);
            }
            ListMutation = listMutation;
        }
        public IActionResult OnGetDelete(string Id)
        {

            var url = WebAppEndpoint.Mutation.DeleteMutation + Id;
            var task = client.DeleteAsync(url);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Delete thành công", 1);
                return RedirectToPage("./Index");
            }
            else 
            {
                return NotFound();
            }
            
        }
    }
}
