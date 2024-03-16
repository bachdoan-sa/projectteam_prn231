using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WebAppRazorpage.Constants
{
    public class WebApiEndpoint
    {
        public const string Host = "https://localhost:7253";
        public const string AreaName = "api";
        
        public static class Account
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/Account";

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
			private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(AuctionEvent);

			public const string GetAllAuctionEvent = BaseEndpoint + "/get-all";
			public const string GetAuctionEvent = BaseEndpoint + "/get-single/{id}";
			public const string AddAuctionEvent = BaseEndpoint + "/add";
			public const string UpdateAuctionEvent = BaseEndpoint + "/update";
			public const string DeleteAuctionEvent = BaseEndpoint + "/delete" + "/{id}";
		}
        public static class AuctionState
        {

        }
        public static class DealHanger
        {
            private const string BaseEndpoint = Host + "/" + AreaName + "/" + nameof(DealHanger);

            public const string GetAllDealHanger = BaseEndpoint;
        }
        public static class Mutation
        {

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
            public const string GetAllOrchidCategory = BaseEndpoint;

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
