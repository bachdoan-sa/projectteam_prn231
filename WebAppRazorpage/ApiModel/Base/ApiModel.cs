using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace WebAppRazorpage.ApiModel.Base
{
    public static class Serialize
    {
        public static string ToJson(this AccountModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this AuctionEventModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this AuctionStateModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this DealHangerModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this MutationModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this OrchidModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this OrchidCategoryModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this OrchidMutationModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this OrderModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this OrderDetailModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this RoleModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this TransactionModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this WalletModel self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

}
