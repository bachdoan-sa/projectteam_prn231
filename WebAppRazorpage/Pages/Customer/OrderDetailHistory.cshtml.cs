using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;

namespace WebAppRazorpage.Pages.Customer
{
    public class OrderDetailHistoryModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();


        public List<OrderDetailModel> ListOrderDetail { get; set; }

        public void OnGet(int Id)
        {
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
        }



    }
}
