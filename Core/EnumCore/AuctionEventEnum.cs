using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.EnumCore
{
    public enum AuctionEventEnum
    {
        Pending = 0,
        Active = 1,
        Live = 2,
        Done = 3,
        Cancel = 4,
        Fail = 5
    }
}
