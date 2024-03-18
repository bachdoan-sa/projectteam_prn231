using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;

namespace WebAppRazorpage.ApiModel
{
    public partial class OrderModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("account")]
        public AccountModel Account { get; set; }

        [JsonProperty("orderDetails")]
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
    public partial class OrderModel
    {
        public static List<OrderModel> FromJson(string json) => JsonConvert.DeserializeObject<List<OrderModel>>(json, Converter.Settings);
        public static OrderModel FromJsonToObject(string json) => JsonConvert.DeserializeObject<OrderModel>(json, Converter.Settings);
    }
}
