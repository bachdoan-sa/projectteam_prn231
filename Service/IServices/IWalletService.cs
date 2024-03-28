using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IWalletService
    {

        public Task<Wallet> GetWalletByAccountId(string id);
        Task<string> UpdateWalletByAccountId(double ballance);
    }
}
