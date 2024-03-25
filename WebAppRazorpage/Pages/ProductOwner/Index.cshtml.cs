using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.ProductOwner
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        [Required(ErrorMessage = "Màu sắc là bắt buộc")]
        public string Color { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Kích thước là bắt buộc")]
        public string Size { get; set; }

        [BindProperty]
        public string Shape { get; set; }
        [BindProperty]
        public string Description { get; set; }

        //[BindProperty]
        //public IFormFile Image { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Giá là bắt buộc")]
        public double? Price { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Category là bắt buộc")]
        public string CategoryId { get; set; }

        [BindProperty]
        public string MutationId { get; set; }

        [BindProperty]
        public List<MutationModel> Mutations { get; set; } = new List<MutationModel>();

        [BindProperty]
        public List<OrchidCategoryModel> Categories { get; set; } = new List<OrchidCategoryModel>();

        [BindProperty]
        public string ReponseMessage { get; set; }


        


        public void OnGet()
        {


            var task = client.GetAsync(WebAppEndpoint.OrchidCategory.GetAllOrchidCategory);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                Categories = OrchidCategoryModel.FromJson(jsonString);
            }

            var task1 = client.GetAsync(WebAppEndpoint.Mutation.GetAllMutation);
            HttpResponseMessage result1 = task1.Result;
            if (result1.IsSuccessStatusCode)
            {
                Task<string> readString1 = result1.Content.ReadAsStringAsync();
                string jsonString1 = readString1.Result;
                Mutations = MutationModel.FromJson(jsonString1);
            }
        }

        public IActionResult OnPost()
        {

            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (accessToken == null)
            {
                return Redirect("/SignIn");
            }
            string json = JsonConvert.SerializeObject(new 
            {

                color = Color,
                name = Name,
                shape = Shape,
                size = Size,
                price = Price,
                productOwnerId = "",
                orchidCategoryId = CategoryId,
                mutationId = MutationId,
                description = Description,
                OrchidStatus = "Active"



            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync("https://localhost:7253/api/Orchids", content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ReponseMessage = readString.Result;
            }
            return Redirect("/ProductOwner/OrchidList");
        }
    }
}

