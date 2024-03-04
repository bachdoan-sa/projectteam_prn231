using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;

namespace WebAppRazorpage.ApiModel
{
    public partial class OrchidModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("orchidStatus")]
        public string OrchidStatus { get; set; }

        [JsonProperty("orchidCategoryId")]
        public string OrchidCategoryId { get; set; }

        [JsonProperty("orchidCategory")]
        public OrchidCategoryModel OrchidCategory { get; set; }

        [JsonProperty("productOwnerId")]
        public string ProductOwnerId { get; set; }

        [JsonProperty("account")]
        public AccountModel Account { get; set; }

        [JsonProperty("orchidMutations")]
        public List<OrchidMutationModel> OrchidMutations { get; set; }

        [JsonProperty("auctionStates")]
        public List<AuctionStateModel> AuctionStates { get; set; }

        [JsonProperty("orderDetails")]
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
    public partial class OrchidModel
    {
        public static List<OrchidModel> FromJson(string json) => JsonConvert.DeserializeObject<List<OrchidModel>>(json, Converter.Settings);
    }
}
