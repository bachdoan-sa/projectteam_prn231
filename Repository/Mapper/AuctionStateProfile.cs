using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Core.Models.OrchidModels;
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
            CreateMap<Orchid, OrchidModel>();

            CreateMap<OrchidAuctionModel, AuctionState>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AuctionState, OrchidAuctionModel>();
        }
    }
}
