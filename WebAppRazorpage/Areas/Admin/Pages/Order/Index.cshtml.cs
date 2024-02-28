using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.Order
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<OrderModel> ListOrder { get; set; }
        public void OnGet()
        {
        

             var task = client.GetAsync(WebApiEndpoint.Order.GetAllOrder);
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