using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;


namespace Woin.Infrastructure.Interface
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        Action<string> Log { get; set; }
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SetModified(object entity);
        int SaveChanges();
    }
}
