using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using WebAppRazorpage.ApiModel;
using WebAppRazorpage.Constants;

namespace WebAppRazorpage.Areas.Admin.Pages.OrderDetail
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient client = new HttpClient();
        [BindProperty]
        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now.Date;
        [BindProperty]
        public DateTimeOffset LastUpdated { get;set; } = DateTimeOffset.Now.Date;
        [BindProperty]
        public string OrderDetailStatus { get; set; }
        [BindProperty]
        public long Cost { get; set; }
        [BindProperty]
        public string OrderId { get; set; }
        [BindProperty]
        public OrderModel Order { get; set; }
        [BindProperty]
        public string OrchidId { get; set; }
        [BindProperty]
        public OrchidModel Orchid { get; set; }
        public string ReponseMessage { get; private set; }

        public void OnPost()
        {
            string json = JsonConvert.SerializeObject(new OrderDetailModel
            {
                CreatedTime = CreatedTime,
                LastUpdated = LastUpdated,
                OrderDetailStatus = OrderDetailStatus,
                Cost = Cost,               
                Order = Order,
                OrderId = OrderId,
                OrchidId = OrchidId,
                Orchid = Orchid,
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var task = client.PostAsync(WebAppEndpoint.OrderDetail.AddOrderDetail, content);
            HttpResponseMessage result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                Task<string> readString = result.Content.ReadAsStringAsync();
                ReponseMessage = readString.Result;
            }
            Redirect("~/Admin/OrderDetail/Create");
        }
    }
}

