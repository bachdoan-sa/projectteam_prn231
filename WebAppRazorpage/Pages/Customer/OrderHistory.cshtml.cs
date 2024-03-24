using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Pages.Customer
{
    public class OrderHistoryModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();


        public List<OrderModel> ListOrder { get; set; }

        public void OnGet(int customerId)
        {
            var task = client.GetAsync($"https://localhost:7253/api/Order/Customer/{customerId}");
            HttpResponseMessage result = task.Result;
            List<OrderModel> listOrder = new List<OrderModel>();
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                string jsonString = readString.Result;
                listOrder = OrderModel.FromJson(jsonString);
            }
            ListOrder = listOrder;
        }
    }
}
