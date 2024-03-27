using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WebAppRazorpage.Constants
{
    public class WebAppEndpoint
    {
        public const string Host = "https://localhost:7253";
        public const string AreaName = "api";
        
        public static class Account
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/Account";

            public const string SignUpAccount = BaseEndpoint + "/signup";
            public const string SignInAccount = BaseEndpoint + "/signin";
            public const string GetUserRole = BaseEndpoint + "/get-user-role";
            public const string GetAllAccount = BaseEndpoint + "/get-all";
            public const string GetAccount = BaseEndpoint + "/get-single";        
            public const string AddAccount = BaseEndpoint + "/add";
            public const string UpdateAccount = BaseEndpoint + "/update";
            public const string DeleteAccount = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class AuctionEvent
        {
			private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(AuctionEvent);

			public const string GetAllAuctionEvent = BaseEndpoint + "/get-all";
			public const string GetAuctionEvent = BaseEndpoint + "/get-single" /* + "/{id}"*/;
            public const string AddAuctionEvent = BaseEndpoint + "/add";
			public const string UpdateAuctionEvent = BaseEndpoint + "/update";
			public const string DeleteAuctionEvent = BaseEndpoint + "/delete" + "/{id}";
		}
        public static class AuctionState
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(AuctionState);

            public const string GetAllAuctionState = BaseEndpoint + "/get-all";
            public const string GetAuctionState = BaseEndpoint + "/get-single";
            public const string AddAuctionState = BaseEndpoint + "/add";
            public const string UpdateAuctionState = BaseEndpoint + "/update";
            public const string DeleteAuctionState = BaseEndpoint + "/delete" + "/{id}";

            public const string GetOrchidAuction = BaseEndpoint + "/get-item" /* + "/{id}"*/;
            public const string GetOrchidAuctions = BaseEndpoint + "/get-items";
            public const string CreateAuctionByOwner = BaseEndpoint + "/CreateAuctionByOwner";
            public const string GetAuctionStateByStatusPending = BaseEndpoint + "/GetAuctionStateByStatusPending";
            public const string GetAuctionStateEnds = BaseEndpoint + "/AuctionStateEnds";
        }
        public static class DealHanger
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(DealHanger);
            public const string RaisePrice = BaseEndpoint + "/raise-price";
            public const string GetAllDealHanger = BaseEndpoint;
            public const string Post = BaseEndpoint + "/add";
            public const string Update = BaseEndpoint + "/update";
            public const string GetDealHanger = BaseEndpoint + "/get-single";
        }
        public static class Mutation
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(Mutation);

            public const string GetAllMutation = BaseEndpoint + "/get-all";
            public const string GetMutation = BaseEndpoint + "/get-single";
            public const string AddMutation = BaseEndpoint + "/add";
            public const string UpdateMutation = BaseEndpoint + "/update";
            public const string DeleteMutation = BaseEndpoint + "/delete" + "/";
        }
        public static class Orchid
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(Orchid);
            public const string GetAllOrchid = BaseEndpoint;
            public const string GetOrchid = BaseEndpoint + "/get-single/{id}";
            public const string AddOrchid = BaseEndpoint + "/add";
            public const string UpdateOrchid = BaseEndpoint + "/update";
            public const string DeleteOrchid = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class OrchidCategory
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(OrchidCategory);
            public const string GetAllOrchidCategory = BaseEndpoint + "/get-all";
            public const string AddOrchidCategory = BaseEndpoint + "/add";
            public const string GetOrchidCategory = BaseEndpoint + "/get-single";
            public const string UpdateOrchidCategory = BaseEndpoint + "/update";

        }
        public static class OrchidMutation
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(OrchidMutation);
            public const string GetAllOrchidMutation = BaseEndpoint;

        }
        public static class Order
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(Order);

            public const string GetAllOrder = BaseEndpoint ;
        }
        public static class OrderDetail
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(OrderDetail);

            public const string GetAllOrderDetail = BaseEndpoint;
        }
        public static class Role
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(Role);

            public const string GetAllRole = BaseEndpoint + "/get-all";
            public const string GetRole = BaseEndpoint + "/get-single";
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
