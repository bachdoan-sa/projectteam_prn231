using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.DeadHangerModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class DealHangerProfile : Profile
    {
        public DealHangerProfile()
        {
            CreateMap<DealHangerHistoryModel, DealHanger>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<DealHanger, DealHangerHistoryModel>();


        }
    }
}

