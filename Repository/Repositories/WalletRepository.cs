using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Base.Interface;
using WebApp.Repository.Base;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Repository.Entities;

namespace WebApp.Repository.Repositories
{
    [ScopedDependency(ServiceType = typeof(IWalletRepository))]
    public class WalletRepository : Repository<Wallet>, IWalletRepository
    {
        public WalletRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
