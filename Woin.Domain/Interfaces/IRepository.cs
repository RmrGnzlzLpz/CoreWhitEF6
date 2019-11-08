using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Woin.Domain.Base;

namespace Woin.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Find(object id);
        T Add(T entity);
        void Delete(T entity);
        void Edit(T entity);

        IEnumerable<T> AddRange(List<T> entities);
        void DeleteRange(List<T> entities);

        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindBy(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
        );
    }
}
