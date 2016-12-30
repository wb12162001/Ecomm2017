using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;

using Quick.Framework.Tool;


namespace Quick.Framework.EFData
{
    /// <summary>
    ///     数据单元操作类
    /// </summary>
    [Export(typeof(IUnitOfWork))]
    public class EFUnitOfWorkContext : UnitOfWorkContextBase
    {
        /// <summary>
        /// 获取 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get
            {
                if(base.WorkContext == EFWorkContext.inetapp)
                {
                    return EFDbContext.Value;
                }
                if (base.WorkContext == EFWorkContext.appdb)
                {
                    return EFAPPDbContext.Value;
                }
                if (base.WorkContext == EFWorkContext.ep_snell)
                {
                    return EFEpsnellDbContext.Value;
                }
                else
                {
                    return EFDbContext.Value;
                }
            }
        }

        [Import("EF", typeof (DbContext))]
        private Lazy<EFDbContext> EFDbContext { get; set; } //延迟初始化的对象的类型。

        [Import("EFAPP", typeof(DbContext))]
        private Lazy<EFAppDbContext> EFAPPDbContext { get; set; } //延迟初始化的对象的类型。

        [Import("EFEPSNELL", typeof(DbContext))]
        private Lazy<EFEpsnellDbContext> EFEpsnellDbContext { get; set; } //延迟初始化的对象的类型。
    }
}