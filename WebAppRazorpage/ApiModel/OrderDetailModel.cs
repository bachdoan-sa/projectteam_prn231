using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;

namespace WebAppRazorpage.ApiModel
{
    public partial class OrderDetailModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset DeleteTime { get; set; }

        [JsonProperty("orderDetailStatus")]
        public string OrderDetailStatus { get; set; }

        [JsonProperty("cost")]
        public long Cost { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("orchidId")]
        public string OrchidId { get; set; }

        [JsonProperty("orchid")]
        public string Orchid { get; set; }
    }
    public partial class OrderDetailModel
    {
        public static List<OrderDetailModel> FromJson(string json) => JsonConvert.DeserializeObject<List<OrderDetailModel>>(json, Converter.Settings);
    }
}
