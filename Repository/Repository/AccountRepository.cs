using Invedia.DI.Attributes;
using Repository.Base;
using Repository.Base.Interface;
using Repository.Entities;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    [ScopedDependency(ServiceType = typeof(IAccountRepository))]
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
