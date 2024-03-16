using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;

namespace WebAppRazorpage.ApiModel
{
    public partial class DealHangerModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public object DeleteTime { get; set; }

        [JsonProperty("dealStatus")]
        public string DealStatus { get; set; }

        [JsonProperty("currency")]
        public long Currency { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("account")]
        public AccountModel Account { get; set; }

        [JsonProperty("auctionStateId")]
        public string AuctionStateId { get; set; }

        [JsonProperty("auctionState")]
        public AuctionStateModel AuctionState { get; set; }
    }
    public partial class DealHangerModel
    {
        public static List<DealHangerModel> FromJson(string json) => JsonConvert.DeserializeObject<List<DealHangerModel>>(json, Converter.Settings);
        public static DealHangerModel FromJsonToObject(string json) => JsonConvert.DeserializeObject<DealHangerModel>(json, Converter.Settings);
    }
}
