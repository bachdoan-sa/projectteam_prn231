using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.OrchidModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class OrchidProfile : Profile
    {
        public OrchidProfile()
        {
            CreateMap<OrchidModel, Orchid>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Orchid, OrchidModel>();


        }
    }
}