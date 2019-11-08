using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Woin.Domain.Base;
using Woin.Domain.Interfaces;
using Woin.Infrastructure.Interface;

namespace Woin.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IDbContext _db;
        protected readonly DbSet<T> _dbset;
        protected GenericRepository(IDbContext context)
        {
            _db = context;
            _dbset = context.Set<T>();
        }
        public virtual T Add(T entity) => _dbset.Add(entity);

        public virtual IEnumerable<T> AddRange(List<T> entities) => _dbset.AddRange(entities);

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void DeleteRange(List<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public virtual void Edit(T entity)
        {
            _db.SetModified(entity);
        }

        public virtual T Find(object id) => _dbset.Find(id);

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbset;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual IEnumerable<T> GetAll() => _dbset.AsEnumerable<T>();
    }
}