using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Base.Interface;
using WebApp.Repository.Base;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories.IRepositories;

namespace WebApp.Repository.Repositories
{
    [ScopedDependency(ServiceType = typeof(IOrderRepository))]
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
