﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.AuctionStateModels
{
    public class AuctionStateModel
    {
        public string Id { get; set; }
        public int Position { get; set; }
        public double? StartingPrice { get; set; }
        public double? ExpectedPrice { get; set; }
        public double? MinRaise { get; set; }
        public double? MaxRaise { get; set; }
        public string AuctionStateStatus { get; set; }
        public double? FinalPrice { get; set; }
    }
}
