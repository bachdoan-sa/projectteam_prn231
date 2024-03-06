using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AccountModels;
using WebApp.Core.Models.RoleModels;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Mapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleModel, Role>().ReverseMap();

        }
    }
}
