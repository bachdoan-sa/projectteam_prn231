using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using WebAppRazorpage.ApiModel;

namespace WebAppRazorpage.Pages.Customer
{
    public class OrderDetailHistoryModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();


        public List<OrderDetailModel> ListOrderDetail { get; set; }

        public IActionResult OnGet(int Id)
        {
            var isAdmin = HttpContext.Session.GetString("IsAdJwToken");
            if (isAdmin != null && isAdmin.Equals("true"))
            {
                return Redirect("/Admin/Index");
            }
            var accessToken = HttpContext.Session.GetString("JwToken");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var task = client.GetAsync($"https://localhost:7253/api/OrderDetail/Order{Id}");
            HttpResponseMessage result = task.Result;
            List<OrderDetailModel> listOrderDetail = new List<OrderDetailModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listOrderDetail = OrderDetailModel.FromJson(jsonString);
            }
            ListOrderDetail = listOrderDetail;
            return Page();
        }



    }
}
