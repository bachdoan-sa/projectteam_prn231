﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.AccountModels;
using WebApp.Repository.Entities;

namespace WebApp.Core.Mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountModel, Account>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Account, AccountModel>();
            CreateMap<AccountRegisterModel, Account>().ReverseMap();
        }
    }
}
