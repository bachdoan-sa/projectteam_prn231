using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;
namespace WebAppRazorpage.ApiModel
{
    public partial class MutationModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("mutationPosition")]
        public string MutationPosition { get; set; }

        [JsonProperty("orchidMutations")]
        public List<OrchidMutationModel> OrchidMutations { get; set; }
    }
    public partial class MutationModel
    {
        public static List<MutationModel> FromJson(string json) => JsonConvert.DeserializeObject<List<MutationModel>>(json, Converter.Settings);
        public static MutationModel FromJsonToObject(string json) => JsonConvert.DeserializeObject<MutationModel>(json, Converter.Settings);
    }
}
