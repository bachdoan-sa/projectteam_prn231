using Microsoft.Extensions.Logging;
using WebApp.Repository.Base.Interface;
using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Base
{
    public abstract class Repository<T> : BaseRepository<T> where T : BaseEntityModel, new()
    {
        public Repository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
