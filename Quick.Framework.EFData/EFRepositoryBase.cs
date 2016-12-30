using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using EntityFramework.Extensions;

using Quick.Framework.Tool;
using Quick.Framework.Tool.Entity;


namespace Quick.Framework.EFData
{
    /// <summary>
    ///     EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    /// 
    public abstract class EFRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class //EntityBase<TKey>
    {
        #region 属性
        protected EFWorkContext ConnectionString;
        public EFRepositoryBase(string connectionString)
        {
            if(connectionString == "appdb")
            {
                this.ConnectionString = EFWorkContext.appdb;
            }
            if (connectionString == "default")
            {
                this.ConnectionString = EFWorkContext.inetapp;
            }
            if (connectionString == "ep_snell")
            {
                this.ConnectionString = EFWorkContext.ep_snell;
            }
        }
        /// <summary>
        ///     获取 仓储上下文的实例
        /// </summary>
        [Import]
        public IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        ///     获取 EntityFramework的数据仓储上下文
        /// </summary>
        protected UnitOfWorkContextBase EFContext
        {
            get
            {
                if (UnitOfWork is UnitOfWorkContextBase)
                {
                    UnitOfWorkContextBase UnitOfWorkBase = UnitOfWork as UnitOfWorkContextBase;
                    UnitOfWorkBase.WorkContext = this.ConnectionString; //切换不同的数据库
                    return UnitOfWorkBase;
                    //return UnitOfWork as UnitOfWorkContextBase;
                }
                throw new DataAccessException(string.Format("数据仓储上下文对象类型不正确，应为UnitOfWorkContextBase，实际为 {0}", UnitOfWork.GetType().Name));
            }
        }

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public virtual IQueryable<TEntity> Entities
        {
            get { return EFContext.Set<TEntity>(); }
        }

        #endregion

        #region 公共方法

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Insert(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterNew<TEntity>(entity);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            EFContext.RegisterNew<TEntity>(entities);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(object id, bool isSave = true)
        {
            PublicHelper.CheckArgument(id, "id");
            TEntity entity = EFContext.Set<TEntity>().Find(id);
            return entity != null ? Delete(entity, isSave) : 0;
        }

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterDeleted<TEntity>(entity);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            EFContext.RegisterDeleted<TEntity>(entities);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            PublicHelper.CheckArgument(predicate, "predicate");
            List<TEntity> entities = EFContext.Set<TEntity>().Where(predicate).ToList();
            return entities.Count > 0 ? Delete(entities, isSave) : 0;
        }

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Update(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterModified<TEntity>(entity);
            return isSave ? EFContext.Commit() : 0;
        }

        /// <summary>
        /// 使用附带新值的实体信息更新指定实体属性的值
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        /// <returns>操作影响的行数</returns>
        public int Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity, bool isSave = true)
        {
            //throw new NotSupportedException("上下文公用，不支持按需更新功能。");
            PublicHelper.CheckArgument(propertyExpression, "propertyExpression");
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterModified<TEntity>(propertyExpression, entity);
            if (isSave)
            {
                var dbSet = EFContext.Set<TEntity>();
                dbSet.Local.Clear();
                var entry = EFContext.DbContext.Entry(entity);
                return EFContext.Commit(false);
            }
            return 0;
        }

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public virtual TEntity GetByKey(object key)
        {
            PublicHelper.CheckArgument(key, "key");
            return EFContext.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// 根据条件获取单条实体数据
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TEntity GetByFiltered(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            var query = EFContext.Set<TEntity>().Where(filter);
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            HandleInclude(ref query, includeProperties);
            return query.FirstOrDefault();
        }

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).Delete();
        }

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="funWhere">查询条件-谓语表达式</param>
        /// <param name="funUpdate">实体-谓语表达式</param>
        /// <returns>操作影响的行数</returns>
        public virtual int Update(Expression<Func<TEntity, bool>> funWhere, Expression<Func<TEntity, TEntity>> funUpdate)
        {
            return Entities.Where(funWhere).Update(funUpdate);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="pageInfo">分页相关信息</param>
        /// <param name="total">总记录数</param>
        /// <returns></returns>
        [Obsolete]
        public virtual IList<dynamic> GetListByPage(IQueryable<dynamic> queryable, PagingInfo pageInfo, out int total)
        {
            // 获取总数
            queryable = queryable.AsNoTracking();
            var q1 = queryable.FutureCount();
            // 获取分页的数据
            var lsitTemp = queryable.Skip(pageInfo.PageIndex).Take(pageInfo.PageSize).Future();
            // 这里会触发上面所有Future函数中的查询包装到一个连接中执行
            total = q1.Value;
            //因为已经得到结果了，这里不会再次查询
            return lsitTemp.ToList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter">where条件</param>
        /// <param name="orderBy">分页信息，会返回查询后的总条数（字段RecCount）</param>
        /// <param name="pageInfo">分页信息，字段RecCount返回总条数，可以不分页，NeedPage=false即可不分页</param>
        /// <param name="includeProperties">include的关联实体s，多个用逗号隔开</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetListByPage(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, PagingInfo pageInfo, string includeProperties = "")
        {
            //纠正分页参数
            pageInfo = pageInfo == null ? new PagingInfo { PageIndex = 1, PageSize = 10 } : pageInfo;
            pageInfo.PageSize = pageInfo.PageSize > 0 ? pageInfo.PageSize : 10;
            IQueryable<TEntity> query = filter != null ? Entities.Where(filter) : Entities;
            HandleInclude(ref query, includeProperties);
            pageInfo.RecCount = query.Count();
            query = orderBy != null ? orderBy(query) : query;
            return pageInfo.NeedPage ? (orderBy != null ? query.Skip((pageInfo.PageIndex - 1) * pageInfo.PageSize).Take(pageInfo.PageSize) : null) : query;
        }

        /// <summary>
        /// 执行非查询sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="behavior">事务属性</param>
        /// <param name="isInsertIdentity">sql语句是否在自增字段插入值</param>
        /// <param name="tableName">操作的表名（可空）</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回影响的行数</returns>
        public virtual int ExcuteNoQuery(string sql, TransactionalBehavior behavior = TransactionalBehavior.DoNotEnsureTransaction, bool isInsertIdentity = false, string tableName = "", params object[] parameters)
        {
            if (isInsertIdentity)
            {
                if (tableName == "") tableName = typeof(TEntity).Name;
                if (sql.TrimEnd().EndsWith(";") == false) sql = sql + ";";
                sql = "SET IDENTITY_INSERT " + tableName + " ON;" + sql + "SET IDENTITY_INSERT " + tableName + "  OFF;";
            }
            return EFContext.DbContext.Database.ExecuteSqlCommand(behavior, sql, parameters);
        }
        /// <summary>
        /// 执行查询sql语句
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public virtual List<T> ExcuteQuery<T>(string sql, params object[] parameters)
        {
            return EFContext.DbContext.Database.SqlQuery<T>(sql, parameters).ToList();
        }

        #endregion

        private void HandleInclude(ref IQueryable<TEntity> query, string includeProperties)
        {
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                   (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
        }
        public bool RemoveHoldingEntityInContext(TEntity entity)
        {
            var objContext = ((IObjectContextAdapter)EFContext.DbContext).ObjectContext;
            var objSet = objContext.CreateObjectSet<TEntity>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);

            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }
        public void RemoveFromContext(TEntity entity)
        {
            PublicHelper.CheckArgument(entity, "entity");
            EFContext.RegisterRemove(entity);
        }

        /// <summary>
        /// 实体修改日志（不含导航属性）
        /// T 必须有主键
        /// 不建议循环调用
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetEntityPropertiesChangedLog(TEntity model)
        {
            var propertiesChangedLog = string.Empty;
            var list = GetEntityPropertiesChanges(model);
            foreach (var tuple in list)
            {
                var displayName = tuple.Item1.Name;
                var displayAttribute = tuple.Item1.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false) as System.ComponentModel.DataAnnotations.DisplayAttribute;
                if (displayAttribute != null && !string.IsNullOrEmpty(displayAttribute.Name))
                {
                    displayName = displayAttribute.Name;
                }

                propertiesChangedLog += string.Format("{0}:{1}->{2};", displayName, tuple.Item2, tuple.Item3);
            }

            return propertiesChangedLog.TrimEnd(';');
        }

        public List<Tuple<PropertyInfo, string, string>> GetEntityPropertiesChanges(TEntity model)
        {
            var result = new List<Tuple<PropertyInfo, string, string>>();
            #region 修改的字段
            var detachFlag = false;
            var propertiesChangedLog = string.Empty;
            var entry = EFContext.DbContext.Entry(model);
            if (entry.State == EntityState.Detached)
            {
                detachFlag = true;
                var keyNames = ((IObjectContextAdapter)EFContext.DbContext).ObjectContext.CreateObjectSet<TEntity>().EntitySet.ElementType.KeyMembers.Select(k => k.Name);
                var propertyValues = new List<object>();
                foreach (var p in model.GetType().GetProperties().Where(m => keyNames.Contains(m.Name)).ToList())
                {
                    propertyValues.Add(p.GetValue(model));
                }
                var dbModel = EFContext.Set<TEntity>().Find(propertyValues.ToArray());
                entry = EFContext.DbContext.Entry(dbModel);
                entry.CurrentValues.SetValues(model);
            }

            foreach (var propertyName in entry.CurrentValues.PropertyNames.Where(m => entry.Property(m).IsModified).ToList())
            {
                if (propertyName.StartsWith("Modified"))
                    continue;
                var property = entry.Property(propertyName);
                var displayName = propertyName;
                var propetyInfo = model.GetType().GetProperty(propertyName);
                result.Add(new Tuple<PropertyInfo, string, string>(propetyInfo, (property.OriginalValue == null ? string.Empty : JsonUtility.ToJson(property.OriginalValue)), (property.CurrentValue == null ? string.Empty : JsonUtility.ToJson(property.CurrentValue))));
            }

            if (detachFlag)
            {
                entry.State = EntityState.Detached;
            }
            #endregion

            return result;
        }
    }
}