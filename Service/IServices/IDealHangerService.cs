using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IDealHangerService
    {
        public Task<List<DealHanger>> GetAllDealhangers();
        public Task<DealHanger> GetDealHangerById(string id);
        public Task<DealHanger> CreateDealHanger(DealHanger dealHanger);
        public Task<string> UpdateDealHanger(DealHanger dealHanger);
    }
}
