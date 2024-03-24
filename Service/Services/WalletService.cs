using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IWalletService))]
    public class WalletService : Base.Service, IWalletService
    {
        private readonly IWalletRepository _repository;

        public WalletService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IWalletRepository>();
        }

        public Task<Wallet> GetWalletByAccountId(string id)
        {
            var wallet = _repository.Get(wallet => wallet.AccountId == id).FirstOrDefaultAsync();
            return wallet;
        }
        public Task<string> UpdateWalletByAccountId(string id, decimal ballance)
        {
            var wallet = _repository.Get(wallet => wallet.AccountId == id).FirstOrDefaultAsync().Result;
            if (wallet == null)
            {
                
                return Task.FromResult("Wallet not found");
            }
            wallet.Balance = ballance.ToString();
            _repository.Update(wallet);
            UnitOfWork.SaveChange();
            return Task.FromResult(wallet.Id);

        }
    }
}
