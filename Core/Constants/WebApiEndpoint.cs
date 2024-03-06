using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Constants
{
    public class WebApiEndpoint
    {
        public const string AreaName = "api";
        
        public static class Account
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Account";

            public const string SignUpAccount = BaseEndpoint + "/signup";
            public const string SignInAccount = BaseEndpoint + "/signin";

            public const string GetAllAccount = BaseEndpoint + "/get-all";
            public const string GetAccount = BaseEndpoint + "/get-single/{id}";        
            public const string AddAccount = BaseEndpoint + "/add";
            public const string UpdateAccount = BaseEndpoint + "/update";
            public const string DeleteAccount = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class AuctionEvent
        {
			private const string BaseEndpoint = "~/" + AreaName + "/" + nameof(AuctionEvent);

			public const string GetAllAuctionEvent = BaseEndpoint + "/get-all";
			public const string GetAuctionEvent = BaseEndpoint + "/get-single/{id}";
			public const string AddAuctionEvent = BaseEndpoint + "/add";
			public const string UpdateAuctionEvent = BaseEndpoint + "/update";
			public const string DeleteAuctionEvent = BaseEndpoint + "/delete" + "/{id}";
		}
        public static class AuctionState
        {
            private const string BaseEndpoint = "~/" + AreaName + "/" + nameof(AuctionState);
            public const string AddAuctionState = BaseEndpoint + "/add";
			public const string UpdateAuctionState = BaseEndpoint + "/update";
			public const string DeleteAuctionState = BaseEndpoint + "/delete" + "/{id}";
            public const string GetOrchidAuction = BaseEndpoint + "get-item/{id}";
            public const string GetOrchidAuctions = BaseEndpoint + "/get-items";
        }
        public static class DealHanger
        {

        }
        public static class Mutation
        {

        }
        public static class Orchid
        {
            
        }
        public static class OrchidCategory
        {

        }
        public static class OrchidMutation
        {

        }
        public static class Order
        {

        }
        public static class OrderDetail
        {

        }
        public static class Role
        {
            private const string BaseEndpoint =  "~/" + AreaName + "/" + nameof(Role);

            public const string GetAllRole = BaseEndpoint + "/get-all";
            public const string GetRole = BaseEndpoint + "/get-single/{id}";
            public const string AddRole = BaseEndpoint + "/add";
            public const string UpdateRole = BaseEndpoint + "/update";
            public const string DeleteRole = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class Transaction
        {

        }
        public static class Wallet
        {

        }
    }
}
