using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.MutationModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class MutatiionProfile : Profile
    {
        public MutatiionProfile()
        {
            CreateMap<MutationModel, Mutation>()
            .ForMember(x => x.Id, opt => opt.Ignore()); ;
            CreateMap<Mutation, MutationModel>();
        }
    }
}
