using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Reflection;
using System.Threading.Tasks;

using Quick.Framework.Tool;
using Quick.Framework.Tool.Entity;


namespace Quick.Framework.EFData
{
    /// <summary>
    ///     定义仓储模型中的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public interface IRepository<TEntity> where TEntity : class //EntityBase<TKey>
    {
        #region 属性

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        #endregion

        #region 公共方法

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(TEntity entity, bool isSave = true);

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Insert(IEnumerable<TEntity> entities, bool isSave = true);

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(object id, bool isSave = true);

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(TEntity entity, bool isSave = true);

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(IEnumerable<TEntity> entities, bool isSave = true);

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true);

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        int Update(TEntity entity, bool isSave = true);

        /// <summary>
        /// 使用附带新值的实体信息更新指定实体属性的值
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="isSave">是否执行保存</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        /// <returns>操作影响的行数</returns>
        int Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity, bool isSave = true);

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        TEntity GetByKey(object key);

        /// <summary>
        /// 通过条件获取单条实体记录
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        TEntity GetByFiltered(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");


        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <returns> 操作影响的行数 </returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="funWhere">查询条件-谓语表达式</param>
        /// <param name="funUpdate">实体-谓语表达式</param>
        /// <returns>操作影响的行数</returns>
        int Update(Expression<Func<TEntity, bool>> funWhere, Expression<Func<TEntity, TEntity>> funUpdate);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="source">查询集合</param>
        /// <param name="pageInfo">分页相关信息</param>
        /// <param name="total">总记录数</param>
        /// <returns></returns>
        [Obsolete]
        IList<dynamic> GetListByPage(IQueryable<dynamic> source, PagingInfo pageInfo, out int total);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter">where条件</param>
        /// <param name="orderBy">分页信息，会返回查询后的总条数（字段RecCount）</param>
        /// <param name="pageInfo">分页信息，字段RecCount返回总条数，可以不分页，NeedPage=false即可不分页</param>
        /// <param name="includeProperties">include的关联实体s，多个用逗号隔开</param>
        /// <returns></returns>
        /// <returns></returns>
        IQueryable<TEntity> GetListByPage(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, PagingInfo pageInfo, string includeProperties = "");


        /// <summary>
        /// 执行非查询sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="behavior">事务属性</param>
        /// <param name="isInsertIdentity">sql语句是否在自增字段插入值</param>
        /// <param name="tableName">操作的表名（可空）</param>
        /// <param name="parameters">参数列表</param>
        /// <returns>返回影响的行数</returns>
        int ExcuteNoQuery(string sql, TransactionalBehavior behavior = TransactionalBehavior.DoNotEnsureTransaction, bool isInsertIdentity = false, string tableName = "", params object[] parameters);

        List<T> ExcuteQuery<T>(string sql, params object[] parameters);

        /// <summary>
        /// 从上下文中脱离（detach）对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool RemoveHoldingEntityInContext(TEntity entity);
        /// <summary>
        /// 从上下文中移除（remove）对象
        /// </summary>
        /// <param name="entity"></param>
        void RemoveFromContext(TEntity entity);

        /// <summary>
        /// 实体修改日志（不含导航属性）
        /// T 必须有主键
        /// 不建议循环调用
        /// </summary>
        /// <returns></returns>
        string GetEntityPropertiesChangedLog(TEntity model);

        /// <summary>
        /// 获取实体属性改变内容
        /// T 必须有主键
        /// 不建议循环调用
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Item1 属性，Item2原值(Json),Item3新值(Json)</returns>
        List<Tuple<PropertyInfo, string, string>> GetEntityPropertiesChanges(TEntity model);

        #endregion
    }
}