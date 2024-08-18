using AngsaStore.Context;
using AngsaStore.Helpers;
using AngsaStore.Services.Interfaces;
using AngsaStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AngsaStore.Services.DALS
{
    public class CategoryDAL : ICategory
    {
        public ApplicationContext db;
        public DbContextTransaction transaction;
        public DbTransaction transaction2;
        private DbContextTransaction Transaction { get; set; }
        private SqlConnection sqlConnection;
        public SqlConnection sqlTrans1;
        private SqlConnection sqlTrans2;
        public CategoryDAL()
        {
            db = new ApplicationContext();
        }

        #region Transaction
        public CategoryDAL BeginTransaction()
        {
            Transaction = db.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            return this;
        }

        public CategoryDAL DoInsert<TEntity>(TEntity entity) where TEntity : class
        {
            db.Set<TEntity>().Add(entity);
            return this;
        }

        public CategoryDAL DoInsert<TEntity>(TEntity entity, out TEntity inserted) where TEntity : class
        {
            inserted = db.Set<TEntity>().Add(entity);
            return this;
        }

        public CategoryDAL DoUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            db.Entry(entity).State = EntityState.Modified;
            return this;
        }

        public CategoryDAL SaveAndContinue()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                // add your exception handling code here
            }
        }

        public bool EndTransaction()
        {
            try
            {
                db.SaveChanges();
                Transaction.Commit();
            }
            catch (DbEntityValidationException dbEx)
            {
                // add your exception handling code here
            }
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            sqlTrans1?.Dispose();
            sqlTrans2?.Dispose();
            db?.Dispose();
        }
        #endregion Transaction

        #region SQL Base
        public MasterCategory GetCategoryDetail(int Id)
        {
            MasterCategory result = new MasterCategory();
            try
            {
                sqlConnection = new SqlConnection(db.ConnectionString);
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("CategoryGetDetail", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            result = MappingDataReader.DataReaderMapToList<MasterCategory>(dataReader).FirstOrDefault();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion SQL Base
    }
}