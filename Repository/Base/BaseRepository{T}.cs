using Microsoft.EntityFrameworkCore;
using Repository.Base.Interface;
using Repository.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntityModel, new()
    {
        protected readonly IDbContext DbContext;
        public BaseRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get
            {
                if (_dbSet != null)
                {
                    return _dbSet;
                }

                _dbSet = DbContext.Set<T>();
                return _dbSet;
            }
        }
        public IQueryable<T> Set() => DbSet.AsNoTracking();
        public virtual void RefreshEntity(T entity)
        {
            DbContext.Entry(entity).Reload();
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            foreach (Expression<Func<T, object>> navigationPropertyPath in includeProperties)
            {
                queryable = queryable.Include(navigationPropertyPath);
            }

            return queryable;
        }

        #region Create (Add)
        public virtual T Add(T entity)
        {
            entity.DeleteTime = null;
            entity = DbSet.Add(entity).Entity;
            return entity;
        }
        public virtual List<T> AddRange(params T[] entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Read (Get/GetSingle) (Tracking Get/GetSingle)
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            if(predicate != null)
            {
                queryable= queryable.Where(predicate); 
            }
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return isIncludeDeleted ? queryable.IgnoreQueryFilters() : queryable.Where((x) => x.DeleteTime == null);
        }
        public virtual T GetSingle(Expression<Func<T, bool>> predicate, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(predicate, isIncludeDeleted, includeProperties).FirstOrDefault();
        }
        #endregion

        #region GetTracking
        public virtual IQueryable<T> GetTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsTracking();
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return predicate == null ? queryable : queryable.Where(predicate);
        }
        public virtual T GetSingleTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return GetTracking(predicate, includeProperties).FirstOrDefault();
        }

        #endregion

        #region Update
        public virtual void Update(T entity)
        {
            TryAttach(entity);
            entity.LastUpdated = DateTimeOffset.UtcNow;
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Update(T entity, params string[] changedProperties)
        {
            TryAttach(entity);
            changedProperties = changedProperties?.Distinct().ToArray();
            if (changedProperties?.Any() ?? false)
            {
                string[] array = changedProperties;
                foreach (string propertyName in array)
                {
                    DbContext.Entry(entity).Property(propertyName).IsModified = true;
                }
            }
            else
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }
        public virtual void Update(T entity, params Expression<Func<T, object>>[] changedProperties)
        {
            TryAttach(entity);
            changedProperties = changedProperties?.Distinct().ToArray();
            if (changedProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = changedProperties;
                foreach (Expression<Func<T, object>> propertyExpression in array)
                {
                    DbContext.Entry(entity).Property(propertyExpression).IsModified = true;
                }
            }
            else
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }
        #endregion

        #region Delete
        public virtual void Delete(T entity)
        {
            try
            {
                TryAttach(entity);
                DbSet.Remove(entity);
            }
            catch (Exception)
            {
                RefreshEntity(entity);
                throw;
            }
        }
        public virtual void Delete(T entity, bool isPhysicalDelete = false)
        {
            try
            {
                TryAttach(entity);
                if (!isPhysicalDelete)
                {
                    entity.DeleteTime =  DateTimeOffset.UtcNow;
                    DbContext.Entry(entity).Property((x) => x.DeleteTime).IsModified = true;
                }
                else
                {
                    DbSet.Remove(entity);
                }
            }
            catch (Exception)
            {
                RefreshEntity(entity);
                throw;
            }
        }
        #endregion
        protected void TryAttach(T entity)
        {
            try
            {
                if (DbContext.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
            }
            catch
            {
            }
        }




    }
}
