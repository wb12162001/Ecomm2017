using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

//using Quick.Framework.EFData.Extensions;
using Quick.Framework.Tool;
using Quick.Framework.Tool.Entity;

namespace Quick.Framework.EFData
{
    public enum EFWorkContext
    {
        appdb,
        inetapp,
        ep_snell,
        gpsps
    }
    /// <summary>
    /// 单元操作实现基类
    /// </summary>
    public abstract class UnitOfWorkContextBase : IUnitOfWorkContext
    {
        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        protected abstract DbContext Context { get; }

        /// <summary>
        /// 获取 当前单元操作是否已被提交
        /// </summary>
        public bool IsCommitted { get; private set; }

        public DbContext DbContext
        {
            get
            {
                return Context;
            }
        }

        public EFWorkContext WorkContext;


        /// <summary>
        /// 提交当前单元操作的结果
        /// </summary>
        /// <param name="validateOnSaveEnabled">保存时是否自动验证跟踪实体</param>
        /// <returns></returns>
        public int Commit(bool validateOnSaveEnabled = true)
        {
            if (IsCommitted)
            {
                return 0;
            }
            try
            {
                int result = Context.SaveChanges(validateOnSaveEnabled);
                IsCommitted = true;
                return result;
            }
            catch (DbEntityValidationException ex)
            {
                var entry = ex.EntityValidationErrors.First().Entry;
                var err = ex.EntityValidationErrors.First().ValidationErrors.First();
                var msg = err.ErrorMessage;
                try
                {
                    var displayName = entry.Entity.GetType().GetProperty(err.PropertyName).GetPropertyDisplayName();
                    msg = string.Format(msg, displayName, entry.CurrentValues.GetValue<object>(err.PropertyName));
                }
                catch (Exception)
                {
                }
                throw new Exception(msg);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException != null && e.InnerException.InnerException is SqlException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    string msg = DataHelper.GetSqlExceptionMessage(sqlEx.Number);
                    throw PublicHelper.ThrowDataAccessException("提交数据更新时发生异常：" + msg, sqlEx);
                }
                throw;
            }
        }

        /// <summary>
        /// 把当前单元操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            IsCommitted = false;
        }

        public void Dispose()
        {
            if (!IsCommitted)
            {
                Commit();
            }
            Context.Dispose();
        }

        /// <summary>
        /// 为指定的类型返回 System.Data.Entity.DbSet，这将允许对上下文中的给定实体执行 CRUD 操作。
        /// </summary>
        /// <typeparam name="TEntity"> 应为其返回一个集的实体类型。 </typeparam>

        /// <returns> 给定实体类型的 System.Data.Entity.DbSet 实例。 </returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : class  //EntityBase<TKey>
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        /// 注册一个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class //EntityBase<TKey>
        {
            System.Data.Entity.EntityState state = Context.Entry(entity).State;
            if (state == System.Data.Entity.EntityState.Detached)
            {
                Context.Entry(entity).State = System.Data.Entity.EntityState.Added;
            }
            IsCommitted = false;
        }

        /// <summary>
        /// 批量注册多个新的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>

        /// <param name="entities"> 要注册的对象集合 </param>
        public void RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class  //EntityBase<TKey>
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterNew<TEntity>(entity);
                }
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        /// 注册一个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public void RegisterModified<TEntity>(TEntity entity) where TEntity : class // EntityBase<TKey>
        {
            Context.Update<TEntity>(entity);
            IsCommitted = false;
        }

        public void RegisterModifiedState<TEntity>(TEntity entity) where TEntity : class // EntityBase<TKey>
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            IsCommitted = false;
        }

        /// <summary>
        /// 使用指定的属性表达式指定注册更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">要注册的类型</typeparam>
        /// <param name="propertyExpression">属性表达式，包含要更新的实体属性</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        public void RegisterModified<TEntity>(Expression<Func<TEntity, object>> propertyExpression, TEntity entity) where TEntity : class // EntityBase<TKey>
        {
            Context.Update<TEntity>(propertyExpression, entity);
            IsCommitted = false;
        }

        /// <summary>
        /// 注册一个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entity"> 要注册的对象 </param>
        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class // EntityBase<TKey>
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            IsCommitted = false;
        }

        /// <summary>
        /// 批量注册多个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"> 要注册的类型 </typeparam>
        /// <param name="entities"> 要注册的对象集合 </param>
        public void RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class // EntityBase<TKey>
        {
            try
            {
                Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (TEntity entity in entities)
                {
                    RegisterDeleted<TEntity>(entity);
                }
            }
            finally
            {
                Context.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        /// <summary>
        ///   从仓储上下文中删除注册的对象
        /// </summary>
        /// <typeparam name="TEntity"> 要删除注册的类型 </typeparam>
        /// <param name="entity"> 要删除的对象 </param>
        public void RegisterRemove<TEntity>(TEntity entity) where TEntity : class// EntityBase<TKey>
        {
            Context.Set<TEntity>().Remove(entity);
            IsCommitted = false;
        }
        /// <summary>
        /// EF SQL 语句返回 dataTable
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet SqlQueryForDataSet(CommandType commandType, string sql, SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection { ConnectionString = Context.Database.Connection.ConnectionString })
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                var cmd = new SqlCommand { Connection = conn, CommandText = sql, CommandType = commandType, CommandTimeout = conn.ConnectionTimeout };
                if (parameters != null && parameters.Length > 0)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }

                var adapter = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adapter.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }
        }

        public void Update<TEntity>(Expression<Func<TEntity, object>> propertyExpression, params TEntity[] entities)
            where TEntity : class
        {
            DbContextExtensions.Update<TEntity>(Context, propertyExpression, entities);
            IsCommitted = false;
        }
    }
}