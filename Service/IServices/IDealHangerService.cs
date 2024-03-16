using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models.DeadHangerModels;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IDealHangerService
    {
        public Task<List<DealHanger>> GetAllDealhangers();
        public Task<DealHanger> GetDealHangerById(string id);
        public Task<string> CreateDealHanger(DealHangerModel dealHanger);
        public Task<string> UpdateDealHanger(DealHanger dealHanger);
        public Task<string> StartAuction(DealHangerModel request);
        public Task<List<DealHangerHistoryModel>> GetByCustomerId(string id);
    }
}
