using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Text;
using Woin.Infrastructure.Interface;

namespace Woin.Infrastructure.Repositories
{
    // [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class DbcontextBase : DbContext, IDbContext
    {
        public DbcontextBase(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbcontextBase(DbConnection connection) : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public Action<string> Log
        {
            get
            {
                return this.Database.Log;
            }
            set
            {
                this.Database.Log = value;
            }
        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
