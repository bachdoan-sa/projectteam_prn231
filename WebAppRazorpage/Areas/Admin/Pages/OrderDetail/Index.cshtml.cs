using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.OrderDetail
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public List<OrderDetailModel> ListOrderDetail { get; set; }
        public void OnGet()
        {


            var task = client.GetAsync(WebApiEndpoint.OrderDetail.GetAllOrderDetail);
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
