using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;
namespace WebAppRazorpage.ApiModel
{
    public partial class OrchidMutationModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("shape")]
        public string Shape { get; set; }

        [JsonProperty("mutationId")]
        public string MutationId { get; set; }

        [JsonProperty("mutation")]
        public MutationModel Mutation { get; set; }

        [JsonProperty("orchidId")]
        public string OrchidId { get; set; }

        [JsonProperty("orchid")]
        public OrchidModel Orchid { get; set; }
    }
    public partial class OrchidMutationModel
    {
        public static List<OrchidMutationModel> FromJson(string json) => JsonConvert.DeserializeObject<List<OrchidMutationModel>>(json, Converter.Settings);
    }
}
