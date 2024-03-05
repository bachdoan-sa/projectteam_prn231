﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core.Models.AuctionEventModels
{
    public class AuctionEventModel
    {
        public string Id { get; set; }
        public DateTime? BeginDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string? AuctionStatus { get; set; }
        public string? StaffId { get; set; }
    }
}
