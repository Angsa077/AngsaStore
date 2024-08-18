using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AngsaStore.Context
{
    public class ApplicationContext : DbContext
    {
        public string ConnectionString;
        public ApplicationContext() : base("name=ApplicationContext")
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = 120;
            ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationContext"].ToString();
        }
        public ApplicationContext(DbConnection existingConnection, bool contextOwnsConnection) :
            base(existingConnection, contextOwnsConnection)
        {

        }
        public ApplicationContext(SqlConnection existingContext, bool contextOwnsContext) :
            base(existingContext, contextOwnsContext)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ApplicationContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}