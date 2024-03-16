

namespace WebAppRazorpage.ApiModel
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WebAppRazorpage.ApiModel.Base;
    public partial class AccountModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("deleteTime")]
        public DateTimeOffset? DeleteTime { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }

        [JsonProperty("passwordSalt")]
        public string PasswordSalt { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("birthdate")]
        public DateTimeOffset? Birthdate { get; set; }

        [JsonProperty("otp")]
        public string Otp { get; set; }

        [JsonProperty("otpCreatedDate")]
        public DateTimeOffset? OtpCreatedDate { get; set; }

        [JsonProperty("otpExpiredDate")]
        public DateTimeOffset? OtpExpiredDate { get; set; }

        [JsonProperty("roleId")]
        public string RoleId { get; set; }

        [JsonProperty("role")]
        public RoleModel? Role { get; set; }

        [JsonProperty("wallets")]
        public List<WalletModel>? Wallets { get; set; }

        [JsonProperty("auctionEvents")]
        public List<AuctionEventModel>? AuctionEvents { get; set; }

        [JsonProperty("orchids")]
        public List<OrchidModel>? Orchids { get; set; }

        [JsonProperty("orders")]
        public List<OrderModel>? Orders { get; set; }

        [JsonProperty("dealHangers")]
        public List<DealHangerModel>? DealHangers { get; set; }
    }
    public partial class AccountModel   
    {
        public static List<AccountModel> FromJson(string json) => JsonConvert.DeserializeObject<List<AccountModel>>(json, Converter.Settings);
    }
}
