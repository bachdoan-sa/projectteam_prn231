using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class AuctionStateProfile : Profile
    {
        public AuctionStateProfile()
        {
            CreateMap<AuctionStateModel, AuctionState>().ReverseMap();
            CreateMap<OrchidAuctionModel, AuctionState>().ReverseMap();
        }
    }
}
