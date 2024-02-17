using Microsoft.Extensions.Logging;
using Repository.Base.Interface;
using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public abstract class Repository<T> : BaseRepository<T> where T : BaseEntityModel, new()
    {
        public Repository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
