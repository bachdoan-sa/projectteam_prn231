using WebApp.Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repository.Base.Interface
{
    public interface IRepository<T> : IBaseRepository<T> where T : BaseEntityModel, new()
    {
    }
}
