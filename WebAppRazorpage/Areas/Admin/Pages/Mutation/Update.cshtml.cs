using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Mutation
{
    public class UpdateModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public string Id { get; set; }        

        [BindProperty]
        public string ReponseMessage { get; set; }
        [BindProperty]
        public MutationModel MutationModel { get; set; }
        private readonly INotyfService _notyf;

        public UpdateModel(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public void OnGet()

        {
        }
        public IActionResult OnPost(string Id)
        {
            string json = Id;

            var url = WebAppEndpoint.Mutation.GetMutation + "/" + json;
            var task = client.GetAsync(url);
            HttpResponseMessage result = task.Result;
            MutationModel mutationModel = new MutationModel();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                mutationModel = MutationModel.FromJsonToObject(jsonString);
            }
            else
            {
                return NotFound();
            }
            MutationModel = mutationModel;
            return Page();
        }
        public IActionResult OnPostUpdate()
        {


            var url = WebAppEndpoint.Mutation.UpdateMutation;
            var task = client.PutAsJsonAsync(url,MutationModel);
            HttpResponseMessage result = task.Result;
            MutationModel mutationModel = new MutationModel();
            if (result.IsSuccessStatusCode)
            {
                _notyf.Success("Update thành công",1);
                return RedirectToPage("./Index");
            }
            else
            {
                return NotFound();
            }
        }



    }
}
