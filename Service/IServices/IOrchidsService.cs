using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using WebApp.Core.Models.AccountModels;

namespace WebApp.Service.IServices
{
    public interface IOrchidsService
    {
        Task<List<Orchid>> GetAllOrchids();
        Task<Orchid> GetOrchidById(string id);
        Task AddOrchid(Orchid orchid);
        Task UpdateOrchid(Orchid orchid);
   
    }
}
