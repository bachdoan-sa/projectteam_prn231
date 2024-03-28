using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Customer
{
    public class OrderHistoryModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();


        public List<OrderModel> ListOrder { get; set; }

        public IActionResult OnGet()
        {
            var isAdmin = HttpContext.Session.GetString("IsAdJwToken");
            if (isAdmin != null && isAdmin.Equals("true"))
            {
                return Redirect("/Admin/Index");
            }
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var task = client.GetAsync($"https://localhost:7253/api/Order/Customer");
            HttpResponseMessage result = task.Result;
            List<OrderModel> listOrder = new List<OrderModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listOrder = OrderModel.FromJson(jsonString);
            }
            ListOrder = listOrder;
            return Page();
        }
    }
}
