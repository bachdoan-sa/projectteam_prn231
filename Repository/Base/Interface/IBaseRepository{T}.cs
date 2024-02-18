using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities.BaseEntity;
namespace WebApp.Repository.Base.Interface
{
    public interface IBaseRepository<T> where T : BaseEntityModel, new()
    {
        void RefreshEntity(T entity);

        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Set();
        T Add(T entity);
        List<T> AddRange(params T[] entities);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(Expression<Func<T, bool>> predicate, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties);
        T GetSingleTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        void Update(T entity, params Expression<Func<T, object>>[] changedProperties);
        void Update(T entity, params string[] changedProperties);
        void Update(T entity);
        void Delete(T entity);
        void Delete(T entity, bool isPhysicalDelete = false);
        /*void DeleteWhere(Expression<Func<T, bool>> predicate, bool isPhysicalDelete = false);
        void DeleteWhere(List<string> ids, bool isPhysicalDelete = false);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void DeleteRange(ICollection<T> entities);*/
    }
}
