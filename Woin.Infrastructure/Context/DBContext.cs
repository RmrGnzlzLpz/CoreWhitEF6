using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Woin.Infrastructure.Repositories;
using Woin.Domain.Entities;

namespace Woin.Infrastructure.Context
{
    public class DBContext : DbcontextBase
    {
        public DBContext() : base("name=DBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DBContext(DbConnection connection) : base(connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Example> Examples { get; set; }
    }
}