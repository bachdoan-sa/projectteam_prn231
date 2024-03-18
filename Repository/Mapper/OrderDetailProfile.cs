using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AuctionStateModels;
using WebApp.Core.Models.OrderDetailModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailModel, OrderDetail>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetailModel>();

           
        }
    }
}
