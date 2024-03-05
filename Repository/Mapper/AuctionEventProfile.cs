using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionEventModels;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class AuctionEventProfile : Profile
    {
        public AuctionEventProfile()
        {
            CreateMap<AuctionEventModel, AuctionEvent>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<AuctionEvent, AuctionEventModel>();

        }
    }
}
