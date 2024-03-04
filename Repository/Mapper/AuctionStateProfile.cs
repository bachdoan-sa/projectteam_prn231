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
            CreateMap<AuctionStateModel, AuctionState>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AuctionState, AuctionStateModel>();

            CreateMap<OrchidAuctionModel, AuctionState>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AuctionState, OrchidAuctionModel>();
        }
    }
}
