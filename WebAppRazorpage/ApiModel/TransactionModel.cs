using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebAppRazorpage.ApiModel.Base;

namespace WebAppRazorpage.ApiModel
{
    public partial class TransactionModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("transactionStatus")]
        public string TransactionStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("reponseTime")]
        public long ReponseTime { get; set; }

        [JsonProperty("walletId")]
        public string WalletId { get; set; }

        [JsonProperty("wallet")]
        public WalletModel? Wallet { get; set; }
    }
    public partial class TransactionModel
    {
        public static List<TransactionModel> FromJson(string json) => JsonConvert.DeserializeObject<List<TransactionModel>>(json, Converter.Settings);
        public static TransactionModel FromJsonToObject(string json) => JsonConvert.DeserializeObject<TransactionModel>(json, Converter.Settings);
    }
}
