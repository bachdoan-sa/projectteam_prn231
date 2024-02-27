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

        }
        public static class AuctionState
        {

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
