using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;

namespace WebAppRazorpage.ApiModel
{
    public partial class WalletModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset DeleteTime { get; set; }

        [JsonProperty("walletType")]
        public string WalletType { get; set; }

        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("transactions")]
        public List<TransactionModel> Transactions { get; set; }
    }
    public partial class WalletModel
    {
        public static List<WalletModel> FromJson(string json) => JsonConvert.DeserializeObject<List<WalletModel>>(json, Converter.Settings);
    }
}
