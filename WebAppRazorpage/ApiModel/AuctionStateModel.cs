using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;
namespace WebAppRazorpage.ApiModel
{
    public partial class AuctionStateModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("position")]
        public int Position { get; set; }

        [JsonProperty("startingPrice")]
        public double? StartingPrice { get; set; }

        [JsonProperty("expectedPrice")]
        public double? ExpectedPrice { get; set; }

        [JsonProperty("minRaise")]
        public double? MinRaise { get; set; }

        [JsonProperty("maxRaise")]
        public double? MaxRaise { get; set; }

        [JsonProperty("auctionStateStatus")]
        public string AuctionStateStatus { get; set; }

        [JsonProperty("finalPrice")]
        public double? FinalPrice { get; set; }

        [JsonProperty("orchidId")]
        public string OrchidId { get; set; }

        [JsonProperty("orchid")]
        public OrchidModel Orchid { get; set; }

        [JsonProperty("auctionEventId")]
        public string AuctionEventId { get; set; }

        [JsonProperty("auctionEvent")]
        public AuctionEventModel? AuctionEvent { get; set; }

        [JsonProperty("dealHangers")]
        public List<DealHangerModel> DealHangers { get; set; }
    }
    public partial class AuctionStateModel
    {
        public static List<AuctionStateModel> FromJson(string json) => JsonConvert.DeserializeObject<List<AuctionStateModel>>(json, Converter.Settings);
        public static AuctionStateModel FromJsonToObject(string json) => JsonConvert.DeserializeObject<AuctionStateModel>(json, Converter.Settings);
    }
}
