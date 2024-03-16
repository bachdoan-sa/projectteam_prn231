using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;
namespace WebAppRazorpage.ApiModel
{
    public partial class OrchidCategoryModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("orchids")]
        public List<OrchidModel> Orchids { get; set; }
    }
    public partial class OrchidCategoryModel
    {
        public static List<OrchidCategoryModel> FromJson(string json) => JsonConvert.DeserializeObject<List<OrchidCategoryModel>>(json, Converter.Settings);
        public static OrchidCategoryModel FromJsonToObject(string json) => JsonConvert.DeserializeObject<OrchidCategoryModel>(json, Converter.Settings);
    }
}
